# BotTest.Part2

SESSION 2

Tipos de Tarjetas
* Animación: reeproducir gift o video muy corto
* Audio
* Heroe
* Miniatura: imagen pequeña con link o texto corto
* Recibo: para datos de compras
* Inicio de sesión: cuando necesitamos autenticarnos en otras plataformas
* videos: reproduce videos de más duracón que las animaciones


Activity replyToConversation = activity.CreateReply("Should go to conversation, in adaptive cards format");
replyToConversation.AttachmentLayout = AttachmentLayoutTypes.Carousel;
replyToConversation.Attachments = new List<Attachment>();

///////////////////            
http://adaptivecards.io/visualizer/

AdaptiveCard card = new AdaptiveCard()
{
    Body = new List<CardElement>()
    {
        new Container()
        {
            Speak = "<s>Hola!</s><s>Esto es una tarjeta adaptable</s>",
            Items = new List<CardElement>()
            {
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
                                    Url = "https://placeholdit.imgix.net/~text?txtsize=65&txt=Adaptive+Cards&w=300&h=300",
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

    // Buttons
    Actions = new List<ActionBase>()
    {
        new ShowCardAction()
        {
            Title = "Formulario",
            Speak = "<s>formulario</s>",
            Card = GetFormulario()
        }
    }
};
            
/////////////////////
            
//Para instalar el Package de Nuget            
Install-Package Microsoft.AdaptiveCards -Version 0.5.0

/////////////////////

Attachment attachment = new Attachment()
{
    ContentType = AdaptiveCard.ContentType,
    Content = card
};

var reply = context.MakeMessage();
reply.Attachments.Add(attachment);

await context.PostAsync(reply, CancellationToken.None);

///////////////////

private static AdaptiveCard GetFormulario()
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

///////////////////
Hacemos cuenta en Marvel
Generamos HASH : http://www.md5.cz/



hash = timestamp + privatekey + publickey 

Timestamp = al azar, puede ser fecha, etc. Usualmente ponemos 9
privatekey: X1
publickey: X2

hash = 9X1X2

 las obtenemos de la pagina de Marvel Developer (https://developer.marvel.com/account) 
y hacemos click en generar Hash
HASH GENERADO: H1


http://gateway.marvel.com/v1/public/characters?apikey=X2&ts=9&hash=9X1X2&name=Iron Man




public static string ImagePathBuilder(string path, string extension, string imageFormat)
        {
            StringBuilder imageBuilder = new StringBuilder();
            imageBuilder.Append(path);
            imageBuilder.Append("/" + imageFormat);
            imageBuilder.Append("." + extension);

            return imageBuilder.ToString();
        }

el bot entiende json
