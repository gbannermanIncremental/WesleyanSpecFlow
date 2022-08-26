using System.IO;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;
using WesSpecFlowExample.Drivers;

namespace CalculatorSelenium.Specs.Hooks
{
    [Binding]
    public class LoggingHooks
    {
        private readonly BrowserDriver browserDriver;
        private readonly ISpecFlowOutputHelper specFlowOutputHelper;
        private readonly ScenarioContext context;

        public LoggingHooks(BrowserDriver browserDriver, ISpecFlowOutputHelper specFlowOutputHelper, ScenarioContext context)
        {
            this.browserDriver = browserDriver;
            this.specFlowOutputHelper = specFlowOutputHelper;
            this.context = context;
        }

        [AfterScenario()]
        public void TakeScreenshotAfterEachStep()
        {

            if (browserDriver.Current is ITakesScreenshot screenshotTaker)
            {
                var filename = Path.ChangeExtension(Path.GetRandomFileName(), "png");
                screenshotTaker.GetScreenshot().SaveAsFile(filename);
                specFlowOutputHelper.WriteLine("Screenshot:");
                specFlowOutputHelper.AddAttachment(filename);
            }
        }

        [AfterScenario()]
        public void onError()
        {
            if (context.TestError != null)
            {
                specFlowOutputHelper.WriteLine("Full error message:");
                specFlowOutputHelper.WriteLine(context.TestError.Message);
                specFlowOutputHelper.WriteLine(context.TestError.InnerException.Message);
                specFlowOutputHelper.WriteLine("Error stacktrace:");
                specFlowOutputHelper.WriteLine(context.TestError.StackTrace);
            }
        }
    }
}