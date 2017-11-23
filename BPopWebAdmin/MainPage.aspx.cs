using BPopWebAdmin.ServicesHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BPopWebAdmin
{
    public partial class MainPage : System.Web.UI.Page
    {
        RestServices services = new RestServices();
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(getUsersList));
            RegisterAsyncTask(new PageAsyncTask(getQuestionsList));
        }
        private async Task getUsersList()
        {
            UsersLiteral.Text = "List of Users: <br />";
            var listOfUsers = await services.GetUsersList();

            UsersLiteral.Text += "<table>" +
                "<tr>" +
                "<th>ID</th> <th>StudentId</th> <th>Name</th> <th>Team</th> <th>Points</th>" +
                "</tr>";

            for (int i = 0; i < listOfUsers.Count; i++)
            {
                //build table
                UsersLiteral.Text += "<tr>";
                UsersLiteral.Text += "<td>" + listOfUsers[i].Id + "</td>";
                UsersLiteral.Text += "<td>" + listOfUsers[i].StudentId + "</td>";
                UsersLiteral.Text += "<td>" + listOfUsers[i].Name + "</td>";
                UsersLiteral.Text += "<td>" + listOfUsers[i].Team + "</td>";
                UsersLiteral.Text += "<td>" + listOfUsers[i].Points + "</td>";
                UsersLiteral.Text += "</tr>";
            }
            UsersLiteral.Text += "</table>";
        }
        private async Task getQuestionsList()
        {
            QuestionsLiteral.Text = "List of Questions and Answers: <br />";
            var listOfQuestions = await services.GetQuestionsList();

            QuestionsLiteral.Text += "<table>" +
                "<tr>" +
                "<th>Question</th> <th>ChoiceA</th> <th>ChoiceB</th> <th>ChoiceC</th> <th>ChoiceD</th> <th>Answer</th>" +
                "</tr>";

            for (int i = 0; i < listOfQuestions.Count; i++)
            {
                //build table
                QuestionsLiteral.Text += "<tr>";
                QuestionsLiteral.Text += "<td>" + listOfQuestions[i].Question + "</td>";
                QuestionsLiteral.Text += "<td>" + listOfQuestions[i].ChoiceA + "</td>";
                QuestionsLiteral.Text += "<td>" + listOfQuestions[i].ChoiceB + "</td>";
                QuestionsLiteral.Text += "<td>" + listOfQuestions[i].ChoiceC + "</td>";
                QuestionsLiteral.Text += "<td>" + listOfQuestions[i].ChoiceD + "</td>";
                QuestionsLiteral.Text += "<td>" + listOfQuestions[i].Answer + "</td>";
                QuestionsLiteral.Text += "</tr>";
            }
            QuestionsLiteral.Text += "</table>";
        }
        private async Task startGame()
        {
            await services.CheckUpdateGameIfSuccess("1", "begin");
            await Task.Delay(5000);
            await services.CheckUpdateGameIfSuccess("1", "stop");
        }
        private async Task insertQuestions()
        {
            EncodeDecoder encodeDecoder = new EncodeDecoder();
            if (encodeDecoder.ContainsAny(Question.Text, ChoiceA.Text, ChoiceB.Text, ChoiceC.Text, ChoiceD.Text, Answer.Text))
            {
                Question.Text = encodeDecoder.encode(Question.Text);
                ChoiceA.Text = encodeDecoder.encode(ChoiceA.Text);
                ChoiceB.Text = encodeDecoder.encode(ChoiceB.Text);
                ChoiceC.Text = encodeDecoder.encode(ChoiceC.Text);
                ChoiceD.Text = encodeDecoder.encode(ChoiceD.Text);
                Answer.Text = encodeDecoder.encode(Answer.Text);
            }
            if (await services.checkInsertQandA(Question.Text, ChoiceA.Text, ChoiceB.Text, ChoiceC.Text, ChoiceD.Text, Answer.Text))
            {
                Response.Write("<script> alert('Question successfully inserted');</script>");
                Question.Text = "";
                ChoiceA.Text = "";
                ChoiceB.Text = "";
                ChoiceC.Text = "";
                ChoiceD.Text = "";
                Answer.Text = "";
                await getQuestionsList();
            }
            else
                Response.Write("<script> alert('Insert failed, try again...');</script>");
        }

        protected void btn_startGame_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(startGame));
        }

        protected void btn_submitQandA_Click(object sender, EventArgs e)
        {
            //insertQuestions
            RegisterAsyncTask(new PageAsyncTask(insertQuestions));
        }
    }
}