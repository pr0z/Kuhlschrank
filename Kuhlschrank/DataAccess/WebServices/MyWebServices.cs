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
    }
}
