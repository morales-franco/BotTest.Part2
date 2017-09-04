using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System.Net.Http;
using Newtonsoft.Json;
using Bot.Marvel.Model;
using Bot.Marvel.Utility;
using System.Collections.Generic;

namespace Bot.Marvel.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            //Probar con Iron Man

            var activity = await result as Activity;
            string newCharacter = activity.Text;
            string finalUrl = string.Format("http://gateway.marvel.com/v1/public/characters?apikey=02979cb4a5638df4fb8715ce06111b95&ts=9&hash=9a1e4776e69c38f8beea605df3d60c52&name={0}", newCharacter);

            HttpClient request = new HttpClient();
            var responseString = await request.GetStringAsync(finalUrl);

            Rootobject deserializedEntity =  JsonConvert.DeserializeObject<Rootobject>(responseString);

            string name = deserializedEntity.data.results[0].name;
            string description = deserializedEntity.data.results[0].description;
            var thumbnail = deserializedEntity.data.results[0].thumbnail;
            string finalPath = Helper.ImagePathBuilder(thumbnail.path, thumbnail.extension, "portrait_uncanny");

            var reply = activity.CreateReply();
            reply.Attachments = new List<Attachment>();

            reply.Attachments.Add( new Attachment()
            {
                Name = name,
                Content = description,
                ContentType = "image/jpg",
                ContentUrl = finalPath
            });

            await context.PostAsync(reply);

            context.Wait(MessageReceivedAsync);
        }
    }
}