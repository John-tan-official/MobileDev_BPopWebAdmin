using BPopWebAdmin.Models;
using BPopWebAdmin.RestClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BPopWebAdmin.ServicesHandler
{
    public class RestServices
    {
        RestClient<Users> restClient = new RestClient<Users>();
        public async Task<List<Users>> GetUsersList()
        {
            return await restClient.getUsersList();
        }
        RestClient<Questions> _restClient = new RestClient<Questions>();
        public async Task<List<Questions>> GetQuestionsList()
        {
            return await _restClient.getQandAList();
        }
        public async Task<bool> checkInsertQandA(string question, string choiceA, string choiceB, string choiceC, string choiceD, string answer)
        {
            return await _restClient.InsertQuestion(question, choiceA, choiceB, choiceC, choiceD, answer);
        }
        RestClient<GameStarter> _RestClient = new RestClient<GameStarter>();
        public async Task<bool> CheckUpdateGameIfSuccess(string id, string begin)
        {
            var check = await _RestClient.updateGameState(id, begin);
            return check;
        }
    }
}