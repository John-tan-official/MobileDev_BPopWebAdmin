using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace BPopWebAdmin.RestClient
{
    public class RestClient<T>
    {
        private const string MainWebServiceUrl = "http://localhost:56116/"; // Put your main host url here
        private const string GetUsersURL = MainWebServiceUrl + "api/usersAPI"; // put your api extension url/uri here
        private const string GetQuestionsAndAnswersURL = MainWebServiceUrl + "api/QandAs/";
        private const string InsertQuestionsAndAnswersURL = MainWebServiceUrl + "api/QandAInsert/";///api/QandAInsert/
        private const string UpdateGameWebServiceUrl = MainWebServiceUrl + "api/UpdateGameState/";


        public async Task<List<T>> getUsersList()
        {
            var httpClient = new HttpClient();

            var response = await httpClient.GetStringAsync(GetUsersURL);

            var obj = JsonConvert.DeserializeObject<List<T>>(response);

            return obj;
        }

        public async Task<List<T>> getQandAList()
        {
            var httpClient = new HttpClient();

            var response = await httpClient.GetStringAsync(GetQuestionsAndAnswersURL);

            var obj = JsonConvert.DeserializeObject<List<T>>(response);

            return obj;
        }
        public async Task<bool> updateGameState(string id, string begin)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(UpdateGameWebServiceUrl + "Id=" + id + "/" + "Begin=" + begin);

            return response.IsSuccessStatusCode;
        }
        //Question=What%20is%20the%20best%20answer/ChoiceA=correct/ChoiceB=wrong%7D/ChoiceC=wronger/ChoiceD=wrongest/Answer=A
        public async Task<bool> InsertQuestion(string question, string choiceA, string choiceB, string choiceC, string choiceD, string answer)
        {
            var httpClient = new HttpClient();
            var url = InsertQuestionsAndAnswersURL + "Question=" + question + "/ChoiceA=" + choiceA + "/ChoiceB=" + choiceB + "/ChoiceC=" + choiceC + "/ChoiceD=" + choiceD + "/Answer=" + answer;
            var response = await httpClient.GetAsync(url);

            return response.IsSuccessStatusCode;
        }
    }
}