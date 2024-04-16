using OpenAI_API;
using System;
using System.Windows.Forms;
using OpenAI_API.Models;
using OpenAI_API.Chat;


namespace AIReview
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            var openAiApiKey = ""; // Replace with your OpenAI API key

            APIAuthentication aPIAuthentication = new APIAuthentication(openAiApiKey);
            OpenAIAPI openAiApi = new OpenAIAPI(aPIAuthentication);


            var chatRequest = new ChatRequest
            {
                Model = Model.GPT4,
                MaxTokens = 500,
                Messages = new ChatMessage[] {
                    new ChatMessage(ChatMessageRole.System, "당신은 가게 주인입니다"),
                    new ChatMessage(ChatMessageRole.User, textBox1.Text + "\n이것은 고객의 리뷰입니다. 이에 대한 가장 좋은 댓글은 무엇입니까?"),
                    new ChatMessage(ChatMessageRole.Assistant, "배민님,😂힘이되는 리뷰 달아주셔서 감사합니다. 😊항상 좋은 음식을 제공하고자 노력하는 마음을 알아주셔서 감사합니다.❤️ 💕앞으로도 변치 않는 마음으로 최선을 다하며 더 나은 맛과 양을 제공드리고자 노력하겠습니다!!🩷 🙇‍♂️다음번에도 꼭잊지 않고 주문해주세요🙏")
                },
                PresencePenalty = 0.1,
                FrequencyPenalty = 0.1
            };

            try
            {
                await openAiApi.Chat.StreamChatAsync(chatRequest, res => textBox2.Text += res.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
