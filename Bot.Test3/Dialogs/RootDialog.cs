using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using AdaptiveCards;
using System.Collections.Generic;
using System.Threading;

namespace Bot.Test3.Dialogs
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
            Activity replyToConversation = activity.CreateReply("Should go to conversation, in adaptive cards format");
            replyToConversation.AttachmentLayout = AttachmentLayoutTypes.Carousel;
            replyToConversation.Attachments = new List<Attachment>();

            AdaptiveCard card = new AdaptiveCard()
            {
                Speak = "<s>Hola!</s><s>Esto es una tarjeta adaptable</s>",
                Body = new List<CardElement>()
                {
                    new Container()
                    {
                        Items = new List<CardElement>()
                        {
                            //Columnas de la tarjeta
                            new ColumnSet()
                            {
                                Columns = new List<Column>()
                                {
                                    new Column()
                                    {
                                         Size = ColumnSize.Auto,
                                         Items = new List<CardElement>()
                                         {
                                             new Image()
                                             {
                                                 Url = "data:image/jpeg;base64,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",
                                                 Size = ImageSize.Medium,
                                                 Style = ImageStyle.Person
                                             }
                                         }
                                    },
                                    new Column()
                                    {
                                        Size = ColumnSize.Stretch,
                                        Items = new List<CardElement>()
                                        {
                                            new TextBlock()
                                            {
                                                Text =  "Hola!",
                                                Weight = TextWeight.Bolder,
                                                IsSubtle = true
                                            },
                                            new TextBlock()
                                            {
                                                Text = "Esto es una tarjeta adaptable",
                                                Wrap = true
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                },
                //Button
                Actions = new List<ActionBase>()
                {
                    new ShowCardAction()
                    {
                        Title="Formulario",
                        Speak ="<s>Formulario</s>",
                        Card = this.GetFormulario()
                    }
                }
            };


            Attachment attachment = new Attachment()
            {
                ContentType = AdaptiveCard.ContentType,
                Content = card
            };

            var reply = context.MakeMessage();
            reply.Attachments.Add(attachment);

            await context.PostAsync(reply, CancellationToken.None);

            context.Wait(MessageReceivedAsync);
        }

        private AdaptiveCard GetFormulario()
        {
            return new AdaptiveCard()
            {
                Body = new List<CardElement>()
                {
                        new TextBlock()
                        {
                            Text = "Formulario Tarjeta adaptable",
                            Speak = "<s>demo ingresar datos </s>",
                            Weight = TextWeight.Bolder,
                            Size = TextSize.Large
                        },
                        new TextBlock() { Text = "Ingresa tu nombre" },
                        new TextInput()
                        {
                            Id = "Nombre",
                            Speak = "<s>Ingresa tu nombre completo </s>",
                            Placeholder = "Nombre, apellidos",
                            Style = TextInputStyle.Text
                        },
                        new TextBlock() { Text = "Fecha de nacimiento" },
                        new DateInput()
                        {
                            Id = "fechaNacimiento",
                            Speak = "<s>Cuando naciste</s>"
                        },
                        new TextBlock() { Text = "Ingresa numero de telefono" },
                        new NumberInput()
                        {
                            Id = "Telefono",
                            Speak = "<s>Numero de telefono</s>"
                        }
                },
                Actions = new List<ActionBase>()
                {
                    new SubmitAction()
                    {
                        Title = "Guardar",
                        Speak = "<s>guardar</s>"
                    }
                }
            };
        }
    }
}