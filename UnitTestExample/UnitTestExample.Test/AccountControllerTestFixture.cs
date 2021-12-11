﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestExample.Controllers;

namespace UnitTestExample.Test
{
    public class AccountControllerTestFixture
    {
        [Test,

            TestCase("abcd1234", false),
            TestCase("irf@uni-corvinus", false),
            TestCase("irf.uni-corvinus", false),
            TestCase("irf@uni-corvinus.hu", true)

            ]

        public void TestValidateEmail(string email, bool expectedResult)
        {
            var accountController = new AccountController();

            var actualResult = accountController.ValidateEmail(email);
                        
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test,
            TestCase("Abc1", false),
            TestCase("abcdabcd", false),
            TestCase("abcdABCD", false),
            TestCase("ABCDABCD", false),
            TestCase("Abc1", false),
            TestCase("Abc1Abc1", true),

            ]

        public void TestValidatePassword(string password, bool expectedResult)
        {

            var accountController = new AccountController();
            
            var actualResult = accountController.ValidatePassword(password);
            
            Assert.AreEqual(expectedResult, actualResult);

        }

    }
}
