using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;
using Webszolgaltatas.Entities;
using Webszolgaltatas.MnbServiceReference;

namespace Webszolgaltatas
{
    public partial class Form1 : Form
    {
        BindingList<RateData> _rates = new BindingList<RateData>();
        BindingList<string> currencies = new BindingList<string>();
        
        public Form1()
        {
            InitializeComponent();
            loadCurrencyxml(getCurrencies());

            cbValuta.DataSource = currencies;
            RefreshData();
        }

        private void RefreshData()
        {
            if (cbValuta.SelectedItem == null) return;

            _rates.Clear();            
            loadXml(getRates());
            dataGridView1.DataSource = _rates;
            makeChart();
        }

        private void makeChart()
        {
            chartRateData.DataSource = _rates;

            var sorozatok = chartRateData.Series[0];
            sorozatok.ChartType = SeriesChartType.Line;
            sorozatok.XValueMember = "Date";
            sorozatok.YValueMembers = "Value";
            sorozatok.BorderWidth = 2;

            var jelmagyarazat = chartRateData.Legends[0];
            jelmagyarazat.Enabled = false;

            var diagramterulet = chartRateData.ChartAreas[0];
            diagramterulet.AxisX.MajorGrid.Enabled = false;
            diagramterulet.AxisY.MajorGrid.Enabled = false;
            diagramterulet.AxisY.IsStartedFromZero = false;
        }

        private void loadXml(string xmlstring)
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(xmlstring);
            foreach (XmlElement item in xml.DocumentElement)
            {
                RateData r = new RateData();
                r.Date = DateTime.Parse(item.GetAttribute("date"));
                var childElement = (XmlElement)item.ChildNodes[0];
                if (childElement != null)
                {
                    r.Currency = childElement.GetAttribute("curr");
                    decimal unit = decimal.Parse(childElement.GetAttribute("unit"));
                    r.Value = decimal.Parse(childElement.InnerText);
                    if (unit != 0)
                        r.Value = r.Value / unit;
                    _rates.Add(r);
                }
            }
        }

        private void loadCurrencyxml(string xmlstring)
        {
            currencies.Clear();
            XmlDocument xml = new XmlDocument ();
            xml.LoadXml (xmlstring);
            foreach (XmlElement item in xml.DocumentElement.ChildNodes[0])
            {
                string s = item.InnerText;
                currencies.Add(s);
            }
        }

        private string getRates()
        {
            var mnbService = new MNBArfolyamServiceSoapClient();
            GetExchangeRatesRequestBody req = new GetExchangeRatesRequestBody();
            req.currencyNames = cbValuta.SelectedItem.ToString();
            req.startDate = tolPicker.Value.ToString("yyyy-MM-dd");
            req.endDate = igPicker.Value.ToString("yyyy-MM-dd");
            var response = mnbService.GetExchangeRates(req);
            var result = response.GetExchangeRatesResult;
            return result;
        }

        private string getCurrencies()
        {
            var mnbService = new MNBArfolyamServiceSoapClient();
            GetCurrenciesRequestBody req = new GetCurrenciesRequestBody();
            var resp = mnbService.GetCurrencies(req);
            string result = resp.GetCurrenciesResult;
            File.WriteAllText("currency.xml", result);

            return resp.GetCurrenciesResult;
        }
        
        private void paramChanged(object sender, EventArgs e)
        {
            RefreshData();
        }
    }
}
