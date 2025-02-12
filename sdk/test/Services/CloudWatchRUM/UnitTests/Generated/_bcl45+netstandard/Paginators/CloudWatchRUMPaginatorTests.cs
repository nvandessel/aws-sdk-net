/*
 * Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
 * 
 * Licensed under the Apache License, Version 2.0 (the "License").
 * You may not use this file except in compliance with the License.
 * A copy of the License is located at
 * 
 *  http://aws.amazon.com/apache2.0
 * 
 * or in the "license" file accompanying this file. This file is distributed
 * on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either
 * express or implied. See the License for the specific language governing
 * permissions and limitations under the License.
 */

/*
 * Do not modify this file. This file is generated from the rum-2018-05-10.normal.json service model.
 */

using Amazon.CloudWatchRUM;
using Amazon.CloudWatchRUM.Model;

using Moq;
using System;
using System.Linq;
using AWSSDK_DotNet35.UnitTests.TestTools;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AWSSDK_DotNet35.UnitTests.PaginatorTests
{
    [TestClass]
    public class CloudWatchRUMPaginatorTests
    {
        private static Mock<AmazonCloudWatchRUMClient> _mockClient;

        [ClassInitialize()]
        public static void ClassInitialize(TestContext a)
        {
            _mockClient = new Mock<AmazonCloudWatchRUMClient>("access key", "secret", Amazon.RegionEndpoint.USEast1);
        }

        [TestMethod]
        [TestCategory("UnitTest")]
        [TestCategory("CloudWatchRUM")]
        public void GetAppMonitorDataTest_TwoPages()
        {
            var request = InstantiateClassGenerator.Execute<GetAppMonitorDataRequest>();

            var firstResponse = InstantiateClassGenerator.Execute<GetAppMonitorDataResponse>();
            var secondResponse = InstantiateClassGenerator.Execute<GetAppMonitorDataResponse>();
            secondResponse.NextToken = null;

            _mockClient.SetupSequence(x => x.GetAppMonitorData(request)).Returns(firstResponse).Returns(secondResponse);
            var paginator = _mockClient.Object.Paginators.GetAppMonitorData(request);
            
            Assert.AreEqual(2, paginator.Responses.ToList().Count);
        }

        [TestMethod]
        [TestCategory("UnitTest")]
        [TestCategory("CloudWatchRUM")]
        [ExpectedException(typeof(System.InvalidOperationException), "Paginator has already been consumed and cannot be reused. Please create a new instance.")]
        public void GetAppMonitorDataTest__OnlyUsedOnce()
        {
            var request = InstantiateClassGenerator.Execute<GetAppMonitorDataRequest>();

            var response = InstantiateClassGenerator.Execute<GetAppMonitorDataResponse>();
            response.NextToken = null;

            _mockClient.Setup(x => x.GetAppMonitorData(request)).Returns(response);
            var paginator = _mockClient.Object.Paginators.GetAppMonitorData(request);

            // Should work the first time
            paginator.Responses.ToList();

            // Second time should throw an exception
            paginator.Responses.ToList();
        }


        [TestMethod]
        [TestCategory("UnitTest")]
        [TestCategory("CloudWatchRUM")]
        public void ListAppMonitorsTest_TwoPages()
        {
            var request = InstantiateClassGenerator.Execute<ListAppMonitorsRequest>();

            var firstResponse = InstantiateClassGenerator.Execute<ListAppMonitorsResponse>();
            var secondResponse = InstantiateClassGenerator.Execute<ListAppMonitorsResponse>();
            secondResponse.NextToken = null;

            _mockClient.SetupSequence(x => x.ListAppMonitors(request)).Returns(firstResponse).Returns(secondResponse);
            var paginator = _mockClient.Object.Paginators.ListAppMonitors(request);
            
            Assert.AreEqual(2, paginator.Responses.ToList().Count);
        }

        [TestMethod]
        [TestCategory("UnitTest")]
        [TestCategory("CloudWatchRUM")]
        [ExpectedException(typeof(System.InvalidOperationException), "Paginator has already been consumed and cannot be reused. Please create a new instance.")]
        public void ListAppMonitorsTest__OnlyUsedOnce()
        {
            var request = InstantiateClassGenerator.Execute<ListAppMonitorsRequest>();

            var response = InstantiateClassGenerator.Execute<ListAppMonitorsResponse>();
            response.NextToken = null;

            _mockClient.Setup(x => x.ListAppMonitors(request)).Returns(response);
            var paginator = _mockClient.Object.Paginators.ListAppMonitors(request);

            // Should work the first time
            paginator.Responses.ToList();

            // Second time should throw an exception
            paginator.Responses.ToList();
        }

    }
}