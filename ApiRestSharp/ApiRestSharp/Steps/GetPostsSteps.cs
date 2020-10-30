using System;
using System.Threading;
using RestSharp;
using ApiRestSharp.Base;
using ApiRestSharp.Model;
using ApiRestSharp.Utilities;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ApiRestSharp.Steps
{
    [Binding]
    class GetPostsSteps
    {
        private Settings _settings;
        public GetPostsSteps(Settings settings) => _settings = settings;
        
        [Given(@"I perform GET operation for ""(.*)""")]
        public void GivenIPerformGETOperationFor(string url)
        {
            _settings.request = new RestRequest(url, Method.GET);
        }

        [Then(@"I perform operation for post ""(.*)""")]
        public void ThenIPerformOperationForPost(int postId)
        {
            Thread.Sleep(2000);
            _settings.request.AddUrlSegment("postid", postId.ToString());
            _settings.response = _settings.restClient.ExecuteAsyncRequest<Posts>(_settings.request).GetAwaiter().GetResult();
        }

        [Then(@"I should see the ""(.*)"" name as ""(.*)""")]
        public void ThenIShouldSeeTheNameAs(string key, string value)
        {
            Console.WriteLine();
            Assert.That(_settings.response.GetResponseObject(key), Is.EqualTo(value), $"The {key} is not matching");
       
        }



    }
}
