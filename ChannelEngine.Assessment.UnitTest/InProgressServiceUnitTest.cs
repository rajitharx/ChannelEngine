using ChannelEngine.BusinessService;
using ChannelEngine.BusinessService.Interface;
using ChannelEngine.Shared.Entity;
using Moq;
using NSubstitute;
using System.Collections.Generic;
using Xunit;

namespace ChannelEngine.Assessment.UnitTest
{
    public class InProgressServiceUnitTest
    {
        [Fact]
        public void GetAllOrdersByStatus()
        {
            IOrderService _orderService = Substitute.For<IOrderService>();
            IProductService _productService = Substitute.For<IProductService>();

            GenerateMoqobjectForGetAllOrdersByStatus(_orderService);
            PopulateGetProductDetailsBySearchKey(_productService);

            var inProgressService = new InProgressService(_orderService, _productService);

            IList<InProgressOrders> inProgressOrders = inProgressService.GetInProgressForTop5SellingProducts();

            Assert.NotNull(inProgressOrders);
            Assert.True(inProgressOrders.Count == 5);
        }

        private void GenerateMoqobjectForGetAllOrdersByStatus(IOrderService _orderService)
        {
            Response<IList<MerchantOrderResponse>> response = new Response<IList<MerchantOrderResponse>>();
            response.Count = 6;
            response.LogId = "test1234567";
            response.SuccessMessage = "";
            response.ValidationErrors = null;


            response.Content = new List<MerchantOrderResponse>();

            #region populate MerchantOrderResponse objects

            MerchantOrderResponse merchantOrderResponse = new MerchantOrderResponse();
            merchantOrderResponse.Id = 10;
            merchantOrderResponse.ChannelName = "Test channel";
            merchantOrderResponse.ChannelId = 1;
            merchantOrderResponse.GlobalChannelName = "Custom Channel";
            merchantOrderResponse.GlobalChannelId = 55;
            merchantOrderResponse.ChannelOrderSupport = "SPLIT_ORDER_LINES";
            merchantOrderResponse.ChannelOrderNo = "CE-TEST-32480";
            merchantOrderResponse.MerchantOrderNo = "GetInProgressData5";
            merchantOrderResponse.Status = "IN_PROGRESS";
            merchantOrderResponse.IsBusinessOrder = false;
            merchantOrderResponse.AcknowledgedDate = "2020-08-15T17:10:58.11+02:00";
            merchantOrderResponse.CreatedAt = "2020-06-15T11:17:15.6833333+02:00";
            merchantOrderResponse.UpdatedAt = "2020-08-15T17:10:58.11+02:00";
            merchantOrderResponse.MerchantComment = null;
            merchantOrderResponse.BillingAddress = new MerchantAddressResponse();
            merchantOrderResponse.ShippingAddress = new MerchantAddressResponse();
            merchantOrderResponse.SubTotalInclVat = 7.50M;
            merchantOrderResponse.SubTotalVat = 1.30M;
            merchantOrderResponse.ShippingCostsVat = 0.00M;
            merchantOrderResponse.TotalInclVat = 7.50M;
            merchantOrderResponse.TotalVat = 1.30M;
            merchantOrderResponse.OriginalSubTotalInclVat = 7.50M;
            merchantOrderResponse.OriginalSubTotalVat = 1.30M;
            merchantOrderResponse.OriginalShippingCostsInclVat = 0.00M;
            merchantOrderResponse.OriginalShippingCostsVat = 0.00M;
            merchantOrderResponse.OriginalTotalInclVat = 7.50M;
            merchantOrderResponse.OriginalTotalVat = 1.30M;
            merchantOrderResponse.Lines = new List<MerchantOrderLineResponse> { };
            MerchantOrderLineResponse merchantOrderLineResponse = new MerchantOrderLineResponse
            {
                ChannelProductNo = "123456",
                MerchantProductNo = "001201 - S",
                Quantity = 1,
                Gtin = "123456001201 - S"
            };
            merchantOrderResponse.Lines.Add(merchantOrderLineResponse);
            merchantOrderResponse.ShippingCostsInclVat = 0.00M;
            merchantOrderResponse.Phone = "+31711000000";
            merchantOrderResponse.Email = "test@channelengine.net";
            merchantOrderResponse.PaymentMethod = "iDEAL";
            merchantOrderResponse.CurrencyCode = "EUR";
            merchantOrderResponse.OrderDate = "2020-06-15T11:17:15.68+02:00";
            merchantOrderResponse.ExtraData = new object();


            MerchantOrderResponse merchantOrderResponse1 = new MerchantOrderResponse();
            merchantOrderResponse1.Id = 10;
            merchantOrderResponse1.ChannelName = "Test channel";
            merchantOrderResponse1.ChannelId = 1;
            merchantOrderResponse1.GlobalChannelName = "Custom Channel";
            merchantOrderResponse1.GlobalChannelId = 55;
            merchantOrderResponse1.ChannelOrderSupport = "SPLIT_ORDER_LINES";
            merchantOrderResponse1.ChannelOrderNo = "CE-TEST-32480";
            merchantOrderResponse1.MerchantOrderNo = "GetInProgressData5";
            merchantOrderResponse1.Status = "IN_PROGRESS";
            merchantOrderResponse1.IsBusinessOrder = false;
            merchantOrderResponse1.AcknowledgedDate = "2020-08-15T17:10:58.11+02:00";
            merchantOrderResponse1.CreatedAt = "2020-06-15T11:17:15.6833333+02:00";
            merchantOrderResponse1.UpdatedAt = "2020-08-15T17:10:58.11+02:00";
            merchantOrderResponse1.MerchantComment = null;
            merchantOrderResponse1.BillingAddress = new MerchantAddressResponse();
            merchantOrderResponse1.ShippingAddress = new MerchantAddressResponse();
            merchantOrderResponse1.SubTotalInclVat = 7.50M;
            merchantOrderResponse1.SubTotalVat = 1.30M;
            merchantOrderResponse1.ShippingCostsVat = 0.00M;
            merchantOrderResponse1.TotalInclVat = 7.50M;
            merchantOrderResponse1.TotalVat = 1.30M;
            merchantOrderResponse1.OriginalSubTotalInclVat = 7.50M;
            merchantOrderResponse1.OriginalSubTotalVat = 1.30M;
            merchantOrderResponse1.OriginalShippingCostsInclVat = 0.00M;
            merchantOrderResponse1.OriginalShippingCostsVat = 0.00M;
            merchantOrderResponse1.OriginalTotalInclVat = 7.50M;
            merchantOrderResponse1.OriginalTotalVat = 1.30M;
            merchantOrderResponse1.Lines = new List<MerchantOrderLineResponse> { };
            MerchantOrderLineResponse merchantOrderLineResponse1 = new MerchantOrderLineResponse
            {
                ChannelProductNo = "123456",
                MerchantProductNo = "001201 - M",
                Quantity = 3,
                Gtin = "123456001201 - M"
            };
            merchantOrderResponse1.Lines.Add(merchantOrderLineResponse);
            merchantOrderResponse1.ShippingCostsInclVat = 0.00M;
            merchantOrderResponse1.Phone = "+31711000000";
            merchantOrderResponse1.Email = "test@channelengine.net";
            merchantOrderResponse1.PaymentMethod = "iDEAL";
            merchantOrderResponse1.CurrencyCode = "EUR";
            merchantOrderResponse1.OrderDate = "2020-06-15T11:17:15.68+02:00";
            merchantOrderResponse1.ExtraData = new object();



            MerchantOrderResponse merchantOrderResponse2 = new MerchantOrderResponse();
            merchantOrderResponse2.Id = 10;
            merchantOrderResponse2.ChannelName = "Test channel";
            merchantOrderResponse2.ChannelId = 1;
            merchantOrderResponse2.GlobalChannelName = "Custom Channel";
            merchantOrderResponse2.GlobalChannelId = 55;
            merchantOrderResponse2.ChannelOrderSupport = "SPLIT_ORDER_LINES";
            merchantOrderResponse2.ChannelOrderNo = "CE-TEST-32480";
            merchantOrderResponse2.MerchantOrderNo = "GetInProgressData5";
            merchantOrderResponse2.Status = "IN_PROGRESS";
            merchantOrderResponse2.IsBusinessOrder = false;
            merchantOrderResponse2.AcknowledgedDate = "2020-08-15T17:10:58.11+02:00";
            merchantOrderResponse2.CreatedAt = "2020-06-15T11:17:15.6833333+02:00";
            merchantOrderResponse2.UpdatedAt = "2020-08-15T17:10:58.11+02:00";
            merchantOrderResponse2.MerchantComment = null;
            merchantOrderResponse2.BillingAddress = new MerchantAddressResponse();
            merchantOrderResponse2.ShippingAddress = new MerchantAddressResponse();
            merchantOrderResponse2.SubTotalInclVat = 7.50M;
            merchantOrderResponse2.SubTotalVat = 1.30M;
            merchantOrderResponse2.ShippingCostsVat = 0.00M;
            merchantOrderResponse2.TotalInclVat = 7.50M;
            merchantOrderResponse2.TotalVat = 1.30M;
            merchantOrderResponse2.OriginalSubTotalInclVat = 7.50M;
            merchantOrderResponse2.OriginalSubTotalVat = 1.30M;
            merchantOrderResponse2.OriginalShippingCostsInclVat = 0.00M;
            merchantOrderResponse2.OriginalShippingCostsVat = 0.00M;
            merchantOrderResponse2.OriginalTotalInclVat = 7.50M;
            merchantOrderResponse2.OriginalTotalVat = 1.30M;
            merchantOrderResponse2.Lines = new List<MerchantOrderLineResponse> { };
            MerchantOrderLineResponse merchantOrderLineResponse2 = new MerchantOrderLineResponse
            {
                ChannelProductNo = "123456",
                MerchantProductNo = "001201 - XS",
                Quantity = 2,
                Gtin = "123456001201 - XS"
            };
            merchantOrderResponse2.Lines.Add(merchantOrderLineResponse);
            merchantOrderResponse2.ShippingCostsInclVat = 0.00M;
            merchantOrderResponse2.Phone = "+31711000000";
            merchantOrderResponse2.Email = "test@channelengine.net";
            merchantOrderResponse2.PaymentMethod = "iDEAL";
            merchantOrderResponse2.CurrencyCode = "EUR";
            merchantOrderResponse2.OrderDate = "2020-06-15T11:17:15.68+02:00";
            merchantOrderResponse2.ExtraData = new object();


            MerchantOrderResponse merchantOrderResponse3 = new MerchantOrderResponse();
            merchantOrderResponse3.Id = 10;
            merchantOrderResponse3.ChannelName = "Test channel";
            merchantOrderResponse3.ChannelId = 1;
            merchantOrderResponse3.GlobalChannelName = "Custom Channel";
            merchantOrderResponse3.GlobalChannelId = 55;
            merchantOrderResponse3.ChannelOrderSupport = "SPLIT_ORDER_LINES";
            merchantOrderResponse3.ChannelOrderNo = "CE-TEST-32480";
            merchantOrderResponse3.MerchantOrderNo = "GetInProgressData5";
            merchantOrderResponse3.Status = "IN_PROGRESS";
            merchantOrderResponse3.IsBusinessOrder = false;
            merchantOrderResponse3.AcknowledgedDate = "2020-08-15T17:10:58.11+02:00";
            merchantOrderResponse3.CreatedAt = "2020-06-15T11:17:15.6833333+02:00";
            merchantOrderResponse3.UpdatedAt = "2020-08-15T17:10:58.11+02:00";
            merchantOrderResponse3.MerchantComment = null;
            merchantOrderResponse3.BillingAddress = new MerchantAddressResponse();
            merchantOrderResponse3.ShippingAddress = new MerchantAddressResponse();
            merchantOrderResponse3.SubTotalInclVat = 7.50M;
            merchantOrderResponse3.SubTotalVat = 1.30M;
            merchantOrderResponse3.ShippingCostsVat = 0.00M;
            merchantOrderResponse3.TotalInclVat = 7.50M;
            merchantOrderResponse3.TotalVat = 1.30M;
            merchantOrderResponse3.OriginalSubTotalInclVat = 7.50M;
            merchantOrderResponse3.OriginalSubTotalVat = 1.30M;
            merchantOrderResponse3.OriginalShippingCostsInclVat = 0.00M;
            merchantOrderResponse3.OriginalShippingCostsVat = 0.00M;
            merchantOrderResponse3.OriginalTotalInclVat = 7.50M;
            merchantOrderResponse3.OriginalTotalVat = 1.30M;
            merchantOrderResponse3.Lines = new List<MerchantOrderLineResponse> { };
            MerchantOrderLineResponse merchantOrderLineResponse3 = new MerchantOrderLineResponse
            {
                ChannelProductNo = "123456",
                MerchantProductNo = "001201 - L",
                Quantity = 4,
                Gtin = "123456001201 - L"
            };
            merchantOrderResponse3.Lines.Add(merchantOrderLineResponse);
            merchantOrderResponse3.ShippingCostsInclVat = 0.00M;
            merchantOrderResponse3.Phone = "+31711000000";
            merchantOrderResponse3.Email = "test@channelengine.net";
            merchantOrderResponse3.PaymentMethod = "iDEAL";
            merchantOrderResponse3.CurrencyCode = "EUR";
            merchantOrderResponse3.OrderDate = "2020-06-15T11:17:15.68+02:00";
            merchantOrderResponse3.ExtraData = new object();

            MerchantOrderResponse merchantOrderResponse4 = new MerchantOrderResponse();
            merchantOrderResponse4.Id = 10;
            merchantOrderResponse4.ChannelName = "Test channel";
            merchantOrderResponse4.ChannelId = 1;
            merchantOrderResponse4.GlobalChannelName = "Custom Channel";
            merchantOrderResponse4.GlobalChannelId = 55;
            merchantOrderResponse4.ChannelOrderSupport = "SPLIT_ORDER_LINES";
            merchantOrderResponse4.ChannelOrderNo = "CE-TEST-32480";
            merchantOrderResponse4.MerchantOrderNo = "GetInProgressData5";
            merchantOrderResponse4.Status = "IN_PROGRESS";
            merchantOrderResponse4.IsBusinessOrder = false;
            merchantOrderResponse4.AcknowledgedDate = "2020-08-15T17:10:58.11+02:00";
            merchantOrderResponse4.CreatedAt = "2020-06-15T11:17:15.6833333+02:00";
            merchantOrderResponse4.UpdatedAt = "2020-08-15T17:10:58.11+02:00";
            merchantOrderResponse4.MerchantComment = null;
            merchantOrderResponse4.BillingAddress = new MerchantAddressResponse();
            merchantOrderResponse4.ShippingAddress = new MerchantAddressResponse();
            merchantOrderResponse4.SubTotalInclVat = 7.50M;
            merchantOrderResponse4.SubTotalVat = 1.30M;
            merchantOrderResponse4.ShippingCostsVat = 0.00M;
            merchantOrderResponse4.TotalInclVat = 7.50M;
            merchantOrderResponse4.TotalVat = 1.30M;
            merchantOrderResponse4.OriginalSubTotalInclVat = 7.50M;
            merchantOrderResponse4.OriginalSubTotalVat = 1.30M;
            merchantOrderResponse4.OriginalShippingCostsInclVat = 0.00M;
            merchantOrderResponse4.OriginalShippingCostsVat = 0.00M;
            merchantOrderResponse4.OriginalTotalInclVat = 7.50M;
            merchantOrderResponse4.OriginalTotalVat = 1.30M;
            merchantOrderResponse4.Lines = new List<MerchantOrderLineResponse> { };
            MerchantOrderLineResponse merchantOrderLineResponse4 = new MerchantOrderLineResponse
            {
                ChannelProductNo = "123456",
                MerchantProductNo = "001201 - XL",
                Quantity = 1,
                Gtin = "123456001201 - XL"
            };
            merchantOrderResponse4.Lines.Add(merchantOrderLineResponse);
            merchantOrderResponse4.ShippingCostsInclVat = 0.00M;
            merchantOrderResponse4.Phone = "+31711000000";
            merchantOrderResponse4.Email = "test@channelengine.net";
            merchantOrderResponse4.PaymentMethod = "iDEAL";
            merchantOrderResponse4.CurrencyCode = "EUR";
            merchantOrderResponse4.OrderDate = "2020-06-15T11:17:15.68+02:00";
            merchantOrderResponse4.ExtraData = new object();

            MerchantOrderResponse merchantOrderResponse5 = new MerchantOrderResponse();
            merchantOrderResponse5.Id = 10;
            merchantOrderResponse5.ChannelName = "Test channel";
            merchantOrderResponse5.ChannelId = 1;
            merchantOrderResponse5.GlobalChannelName = "Custom Channel";
            merchantOrderResponse5.GlobalChannelId = 55;
            merchantOrderResponse5.ChannelOrderSupport = "SPLIT_ORDER_LINES";
            merchantOrderResponse5.ChannelOrderNo = "CE-TEST-32480";
            merchantOrderResponse5.MerchantOrderNo = "GetInProgressData5";
            merchantOrderResponse5.Status = "IN_PROGRESS";
            merchantOrderResponse5.IsBusinessOrder = false;
            merchantOrderResponse5.AcknowledgedDate = "2020-08-15T17:10:58.11+02:00";
            merchantOrderResponse5.CreatedAt = "2020-06-15T11:17:15.6833333+02:00";
            merchantOrderResponse5.UpdatedAt = "2020-08-15T17:10:58.11+02:00";
            merchantOrderResponse5.MerchantComment = null;
            merchantOrderResponse5.BillingAddress = new MerchantAddressResponse();
            merchantOrderResponse5.ShippingAddress = new MerchantAddressResponse();
            merchantOrderResponse5.SubTotalInclVat = 7.50M;
            merchantOrderResponse5.SubTotalVat = 1.30M;
            merchantOrderResponse5.ShippingCostsVat = 0.00M;
            merchantOrderResponse5.TotalInclVat = 7.50M;
            merchantOrderResponse5.TotalVat = 1.30M;
            merchantOrderResponse5.OriginalSubTotalInclVat = 7.50M;
            merchantOrderResponse5.OriginalSubTotalVat = 1.30M;
            merchantOrderResponse5.OriginalShippingCostsInclVat = 0.00M;
            merchantOrderResponse5.OriginalShippingCostsVat = 0.00M;
            merchantOrderResponse5.OriginalTotalInclVat = 7.50M;
            merchantOrderResponse5.OriginalTotalVat = 1.30M;
            merchantOrderResponse5.Lines = new List<MerchantOrderLineResponse> { };
            MerchantOrderLineResponse merchantOrderLineResponse5 = new MerchantOrderLineResponse
            {
                ChannelProductNo = "123456",
                MerchantProductNo = "001201 - XX",
                Quantity = 1,
                Gtin = "123456001201 - XX"
            };
            merchantOrderResponse5.Lines.Add(merchantOrderLineResponse);
            merchantOrderResponse5.ShippingCostsInclVat = 0.00M;
            merchantOrderResponse5.Phone = "+31711000000";
            merchantOrderResponse5.Email = "test@channelengine.net";
            merchantOrderResponse5.PaymentMethod = "iDEAL";
            merchantOrderResponse5.CurrencyCode = "EUR";
            merchantOrderResponse5.OrderDate = "2020-06-15T11:17:15.68+02:00";
            merchantOrderResponse5.ExtraData = new object();

            #endregion

            response.Content.Add(merchantOrderResponse1);
            response.Content.Add(merchantOrderResponse2);
            response.Content.Add(merchantOrderResponse3);
            response.Content.Add(merchantOrderResponse4);
            response.Content.Add(merchantOrderResponse5);
            response.Content.Add(merchantOrderResponse);

            _orderService.GetAllOrdersByStatus(Shared.Enumerations.OrderStatusEnum.IN_PROGRESS)
                .Returns(response);
        }

        private void PopulateGetProductDetailsBySearchKey(IProductService _productService)
        {
            Response<IList<MerchantProductResponse>> response = new Response<IList<MerchantProductResponse>>();
            response.Content = new List<MerchantProductResponse>();
            MerchantProductResponse merchantProductResponse = new MerchantProductResponse
            {
                Name = "Testing name 001201 - M"
            };
            response.Content.Add(merchantProductResponse);

            _productService.GetProductDetailsBySearchKey("001201 - M").Returns(response);

            /*-------------------------------------------------------------------------------------------------*/

            Response<IList<MerchantProductResponse>> response1 = new Response<IList<MerchantProductResponse>>();
            response1.Content = new List<MerchantProductResponse>();
            MerchantProductResponse merchantProductResponse1 = new MerchantProductResponse
            {
                Name = "Testing name 001201 - XS"
            };
            response1.Content.Add(merchantProductResponse1);

            _productService.GetProductDetailsBySearchKey("001201 - XS").Returns(response1);

            /*-------------------------------------------------------------------------------------------------*/

            Response<IList<MerchantProductResponse>> response2 = new Response<IList<MerchantProductResponse>>();
            response2.Content = new List<MerchantProductResponse>();
            MerchantProductResponse merchantProductResponse2 = new MerchantProductResponse
            {
                Name = "Testing name 001201 - L"
            };
            response2.Content.Add(merchantProductResponse2);

            _productService.GetProductDetailsBySearchKey("001201 - L").Returns(response2);

            /*-------------------------------------------------------------------------------------------------*/

            Response<IList<MerchantProductResponse>> response3 = new Response<IList<MerchantProductResponse>>();
            response3.Content = new List<MerchantProductResponse>();
            MerchantProductResponse merchantProductResponse4 = new MerchantProductResponse
            {
                Name = "Testing name 001201 - XL"
            };
            response3.Content.Add(merchantProductResponse4);

            _productService.GetProductDetailsBySearchKey("001201 - XL").Returns(response3);

            /*-------------------------------------------------------------------------------------------------*/

            Response<IList<MerchantProductResponse>> response4 = new Response<IList<MerchantProductResponse>>();
            response4.Content = new List<MerchantProductResponse>();
            MerchantProductResponse merchantProductResponse5 = new MerchantProductResponse
            {
                Name = "Testing name 001201 - XX"
            };
            response4.Content.Add(merchantProductResponse5);

            _productService.GetProductDetailsBySearchKey("001201 - XX").Returns(response4);

            /*-------------------------------------------------------------------------------------------------*/

            Response<IList<MerchantProductResponse>> response5 = new Response<IList<MerchantProductResponse>>();
            response5.Content = new List<MerchantProductResponse>();
            MerchantProductResponse merchantProductResponse6 = new MerchantProductResponse
            {
                Name = "Testing name 001201 - S"
            };
            response5.Content.Add(merchantProductResponse6);

            _productService.GetProductDetailsBySearchKey("001201 - S").Returns(response5);

            /*-------------------------------------------------------------------------------------------------*/
        }
    }
}