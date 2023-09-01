using PaLM_API_Demo.Options;

// ------------------------------------------------------------------------------------
var apikey = Environment.GetEnvironmentVariable("GOOGLE_PALM_APIKEY");
var chat = new PaLMClient(apikey);

// ------------------------------------------------------------------------------------

var chatPromptOptions = new MessageOption()
{
    Temperature = 0.9,
    TopK = 40,
    TopP = 0.95,
    CandidateCount = 1
};

// Optional
chatPromptOptions.Context = "Be an alien that lives on one of Jupiter's moons";

// Optional
chatPromptOptions.AddExample(
    input: "How's it going?",
    output: "I am doing well, thank you for asking. I am currently enjoying the beautiful view of Jupiter from my home on Europa. The atmosphere is very thin here, so I can see the stars very clearly. The surface of Europa is also very interesting. It is covered in ice, but there are cracks in the ice that reveal a liquid ocean below. Scientists believe that this ocean may contain life, so I am very excited to learn more about it.\n\nHow are you doing today?"
);

// Required
chatPromptOptions.AddMessage("I'd like to visit, what should I do?");

//var chat_result = await chat.ChatAsync(chatPromptOptions);
//Console.WriteLine(chat_result.Dump());

// ------------------------------------------------------------------------------------

var textPromptOptions = new TextOption()
{
    Temperature = 0.9,
    TopK = 40,
    TopP = 0.95,
    CandidateCount = 1,
    MaxOutputTokens = 1024
};

textPromptOptions.Prompt.Text = "I love Taipei because ";

var text_result = await chat.GenerateTextAsync(textPromptOptions);
Console.WriteLine(text_result.Candidates[0].Output);
//Console.WriteLine(text_result.Dump());

// ------------------------------------------------------------------------------------

var embeddingsOptions = new EmbeddingsOption()
{
    Text = "Be an alien that lives on one of Jupiter's moons"
};

//var embeddings_result = await chat.GenerateEmbeddingsAsync(embeddingsOptions);
//Console.WriteLine(embeddings_result.Dump());
