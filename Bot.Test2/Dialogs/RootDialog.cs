using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System.Collections.Generic;

namespace Bot.Test2.Dialogs
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
            var activity = await result as Activity;

            var reply = activity.CreateReply();
            reply.Attachments = new List<Attachment>();
            reply.Attachments.Add( new Attachment() {
                Name = "Control Prueba",
                Content = "Probando mi bot",
                ContentUrl = "https://vignette4.wikia.nocookie.net/marvelmovies/images/1/19/TheAvengers_IronMan.jpg/revision/latest?cb=20120507035040",
                ContentType="image/jpg"

            });

            await context.PostAsync(reply);

      
            context.Wait(MessageReceivedAsync);
        }
    }
}