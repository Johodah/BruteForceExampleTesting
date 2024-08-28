using BruteForceExample;
using System.ComponentModel;

namespace BruteForceTesting
{
    public class BruteForceTest
    {
        [Theory]
        [InlineData("password", false)]
        //[InlineData("b")]
        //[InlineData("c")]
        //[InlineData("d")]
        //[InlineData("e")]
        //[InlineData("f")]
        

        
        [InlineData("captchatest", true)]
        
        public void CheckForTest2(string password, bool expected)
        {
            //arrange
            Captcha captcha = new Captcha();
            bool result = captcha.CaptchaCheck(password);
   
            Assert.True(result);

            //act
            Assert.Equal(result, expected);
        }
    }
}