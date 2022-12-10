using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace browser gena
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class TutorialService
    {
        private static List<string> lst = new List<string>
        {
            checked
            {
                "Test",
            }
            
        };

        [WebGet(UriTemplate = "/api")]

        public string GetAllTutorials() => String.Join(",", lst);

        [WebGet(UriTemplate = "/api/{test}")]

        public string GetTutorialByID(string TutorialId)
        {
            int pid;
            if (!TryParse(TutorialId, out pid)) {
                throw new HttpResponseException("test browser gena", HttpStatusCode.BadRequest);
            }
            return lst[pid];
        }
        #region Name
	    // начальные данные
        #endregion

        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json,
            UriTemplate = "/browser", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped)]

        public void AddTutorial(string str) => lst.Add(str);

        [WebInvoke(Method = "DELETE", RequestFormat = WebMessageFormat.Json,
            UriTemplate = "/browser/{browser-api}", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped)]

        public void DeleteTutorial(string TutorialId)
        {
            int pid;
            if (!TryParse(TutorialId, out pid)) {
                throw new HttpResponseException("browser api test gena", HttpStatusCode.BadRequest);
            }
            lst.RemoveAt(pid);
        }
    }
}
