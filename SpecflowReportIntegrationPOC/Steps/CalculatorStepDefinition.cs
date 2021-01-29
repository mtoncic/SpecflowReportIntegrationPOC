using Calculator;
using Shouldly;
using TechTalk.SpecFlow;

namespace SpecflowReportIntegrationPOC.Steps
{
    [Binding]
    [Scope(Feature = "SimpleCalculator")]
    public sealed class CalculatorStepDefinitions
    {
        private int _firstNumber, _secondNumber, _result;

        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {
            _firstNumber = number;
        }

        [Given("the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {
            _secondNumber = number;
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            _result = SimpleCalculatorService.SumUpTwoNumbers(_firstNumber, _secondNumber);
        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(int result)
        {
            _result.ShouldBe(result);
        }
    }
}