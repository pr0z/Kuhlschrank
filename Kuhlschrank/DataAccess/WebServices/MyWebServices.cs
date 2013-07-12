using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.WebServices
{
    public static class MyWebServices
    {
        private static bool IsInGoodState(CommunicationState state)
        {
            return state == CommunicationState.Opened || state == CommunicationState.Opening || state == CommunicationState.Created;
        }

        #region UserService
        private static UserService.UserServiceClient _usc;
        public static UserService.UserServiceClient UserService
        {
            get
            {
                if (_usc == null || !IsInGoodState(_usc.State))
                {
                    _usc = new UserService.UserServiceClient();
                    _usc.Open();
                }
                return _usc;
            }
        }
        #endregion

        #region ProductService
        private static ProductService.ProductServiceClient _upc;
        public static ProductService.ProductServiceClient ProductService
        {
            get
            {
                if (_upc == null || !IsInGoodState(_upc.State))
                {
                    _upc = new ProductService.ProductServiceClient();
                    _upc.Open();
                }
                return _upc;
            }
        }
        #endregion

        #region DeviceService
        private static DeviceService.DeviceServiceClient _udc;
        public static DeviceService.DeviceServiceClient DeviceService
        {
            get
            {
                if (_udc == null || !IsInGoodState(_udc.State))
                {
                    _udc = new DeviceService.DeviceServiceClient();
                    _udc.Open();
                }
                return _udc;
            }
        }
        #endregion

        #region CategoryService
        private static CategoryService.CategoryServiceClient _ucc;
        public static CategoryService.CategoryServiceClient CategoryService
        {
            get
            {
                if (_ucc == null || !IsInGoodState(_ucc.State))
                {
                    _ucc = new CategoryService.CategoryServiceClient();
                    _ucc.Open();
                }
                return _ucc;
            }
        }
        #endregion

        #region UserProductService
        private static UserProductsService.UserProductsServiceClient _upsc;
        public static UserProductsService.UserProductsServiceClient UserProductsService
        {
            get
            {
                if (_upsc == null || !IsInGoodState(_upsc.State))
                {
                    _upsc = new UserProductsService.UserProductsServiceClient();
                    _upsc.Open();
                }
                return _upsc;
            }
        }
        #endregion

        #region RecetteService
        private static RecetteService.RecetteServiceClient _rsc;
        public static RecetteService.RecetteServiceClient RecetteService
        {
            get
            {
                if (_rsc == null || !IsInGoodState(_rsc.State))
                {
                    _rsc = new RecetteService.RecetteServiceClient();
                    _rsc.Open();
                }
                return _rsc;
            }
        }
        #endregion
    }
}
