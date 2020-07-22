using PracticalTest.Interfaces;
using OpenQA.Selenium;
using PracticalTest.Common;

namespace PracticalTest.Objects
{
    //A page object in the form of calculator
    public class WebCalculator : CommonWebBase, ICalculator
    {
        private readonly By _leftNumberTexBox = By.Id("leftNumber");
        private readonly By _rightNumberTextBox = By.Id("rightNumber");
        private readonly By _resultTextBox = By.ClassName("result");
        private readonly By _operatorList = By.Id("operator");
        private readonly By _iFrame = By.TagName("iframe");
        private readonly By _calculateButton = By.Id("calculate");
        private string _result = null;

        public WebCalculator(IWebDriver driver) : base(driver)
        {
        }

        public int Calculate(int leftNumber, int rightNumber, char operatorUsed)
        {
            return this.SetLeftNumber(leftNumber)
                .SetRightNumber(rightNumber)
                .SetOperator(operatorUsed)
                .ClickCalculateButton()
                .GetResult();
        }

        private WebCalculator SetLeftNumber(int leftNumber)
        {
            SwitchToDefaultContent();
            InputText(_leftNumberTexBox, leftNumber.ToString());
            return this;
        }

        private WebCalculator SetRightNumber(int rightNumber)
        {
            SwitchToDefaultContent();
            InputText(_rightNumberTextBox, rightNumber.ToString());
            return this;
        }

        private WebCalculator ClickCalculateButton()
        {
            SwitchToIFrame(_iFrame);
            ClickElement(_calculateButton);
            return this;
        }

        private WebCalculator SetOperator(char operatorUsed)
        {
            SwitchToDefaultContent();
            SelectItemInDropDown(_operatorList,operatorUsed.ToString());
            return this;
        }

        private int GetResult()
        {
            Driver.SwitchTo().DefaultContent();

            _result = _result == null 
                ? GetValueFromElement(_resultTextBox)
                : GetDifferentValueFromElement(_resultTextBox, _result);
            return int.Parse(_result);
        }
    }
}