using Microsoft.CognitiveServices.Speech;
using System;
using System.Net.NetworkInformation;
using System.Resources;
using FFMpegCore;

public class Program
{
    // prompt
    //can you create a detailed, funny, swear word, and insult filled back and forth between Davis and Jenny about whether mortal kombat is better than street fighter,  making it clear who is speaking when and which style they are speaking in. Davis has the following styles: chat, angry, excited, friendly, cheerful, hopeful, terrified, unfriendly, shouting. Jenny has the same styles. do not include any preamble before or after, just jump right into the start of the debate. the format should be Name (style): dialog. example: Davis (angry): test dialog.   Have them go back and forth at least 10 times each. do not use any styles i have not listed
    public static async Task Main()
    {
        string topic = "Cars (2006) Review";

        string subscribeDisclaimer = $"\r\n\r\nThanks for sticking around until the end of the video. If you enjoyed it, please be sure to give it a like, and subscribe to the channel if you haven't!!!";

        string content = $"\"Automotive Absurdities: A Hilarious Road Trip Through Pixar's Cars\"\r\n\r\nLadies and gentlemen, start your engines and prepare for a high-octane, laughter-fueled journey through the world of Pixar's 2006 animated classic, Cars. With its loveable cast of anthropomorphic vehicles and endearing story of friendship and redemption, Cars has raced its way into our hearts. But beneath its shiny exterior lies a treasure trove of illogical hilarity that deserves a closer, more snarky examination.\r\n\r\nFirst and foremost, we must address the elephant in the room—or rather, the car in the showroom: How does a world inhabited entirely by sentient vehicles actually function? Are these automobiles the evolutionary descendants of the cars we know and love today, or are they the result of some bizarre, vehicular uprising that wiped out humanity? And if the latter, why do they still have door handles? The film offers no answers, but it does provide us with plenty of chuckles as we ponder the implications.\r\n\r\nSpeaking of unanswered questions, let's discuss the curious case of Cars' economy. The film is set in the once-thriving town of Radiator Springs, which has fallen on hard times since the construction of the interstate bypass. However, one must wonder how an economy built entirely on vehicular consumers actually works. For example, is there a stock market where shares of Car and Driver magazine are traded? And what about the automotive food chain? Do smaller cars live in constant fear of being consumed by larger, more powerful vehicles? Your guess is as good as mine.\r\n\r\nMoving on to the film's protagonist, Lightning McQueen, a brash, young racecar who finds himself stranded in Radiator Springs while en route to the Piston Cup Championship. Lightning's journey from selfish hotshot to humble friend is at the heart of the film, but it's hard not to snicker at the fact that he's essentially a car undergoing a midlife crisis. Is it only a matter of time before Lightning trades in his flashy red paint job for a more practical minivan?\r\n\r\nAnd let's not forget about Mater, the lovable tow truck who serves as Lightning's unlikely mentor and friend. Mater is a source of endless amusement, but one can't help but wonder about the implications of his hillbilly status within the Cars universe. Does Mater come from a long line of tow trucks who never quite made it out of the junkyard, or did he simply choose a life of leisurely towing and backward driving? Either way, his presence in the film is a welcome distraction from the more baffling aspects of the Cars world.\r\n\r\nNow, for a moment, let's focus on the film's antagonist, Chick Hicks. This conniving, green racecar is the epitome of the classic sports rival, complete with his own obnoxious catchphrase (Kachigga!). However, it's somewhat amusing that Chick's entire existence seems to revolve around his competition with Lightning McQueen. With no human drivers or teams to back them, it's as if these cars are locked in an eternal struggle for vehicular supremacy, with no clear endgame in sight.\r\n\r\nContinuing our journey through the illogical world of Cars, we arrive at the racing sequences. The film's thrilling races showcase Pixar's impressive animation skills, but they also beg the question: How do cars compete in a race with no human drivers? Are they all operating on some sort of advanced autopilot, or do they possess an innate understanding of racing tactics that rivals that of professional drivers? And for that matter, how are the races even organized? Are there car unions and governing bodies that establish the rules and regulations of the sport? It's enough to make your engine overheat just thinking about it.\r\n\r\nAs we continue to dissect the film, let's take a moment to examine the romantic subplot between Lightning McQueen and Sally, a sassy Porsche who runs the local Cozy Cone Motel. Their budding relationship is undeniably sweet, but it also raises some perplexing questions about car reproduction. Are there car weddings? Car honeymoons? And most importantly, how exactly do new cars come into existence? Are they manufactured on an assembly line, or is there some sort of car-based method of procreation we're blissfully unaware of? The mysteries of the Cars universe never cease to amaze.\r\n\r\nNow, let's address the matter of car healthcare. Throughout the film, we see various vehicles receiving repairs and tune-ups from their fellow automotive denizens. It's an amusing concept, but it also begs the question: Are there car doctors and car hospitals? Is there a comprehensive car healthcare system that rivals our own? And if so, are there car insurance companies to help foot the bill? It's enough to give even the most seasoned mechanic a headache.\r\n\r\nLet's not forget the delightful cameo by real-life automotive legend Jay Leno as Jay Limo, the late-night talk show host with a penchant for cars. This clever nod to Leno's well-known love of automobiles is a hilarious touch, but it also raises even more questions about the Cars universe. Are there other car celebrities who have crossed over from the human world? Do cars watch television shows and movies starring their own kind, or do they prefer content created by their now-extinct human counterparts? The possibilities are truly endless.\r\n\r\nFinally, we arrive at the film's climactic Piston Cup race, where Lightning sacrifices his own victory to help his injured competitor, The King, finish his final race with dignity. It's a touching moment that teaches an important lesson about sportsmanship, but it also leaves us wondering: What does a car retirement look like? Are there car nursing homes where elderly vehicles can live out their golden years, or do they simply rust away in some forgotten junkyard, waiting for their eventual scrapheap fate?\r\n\r\nOne can't help but wonder about the car justice system as well. In a world where cars are the sole inhabitants, are there car police officers patrolling the streets, car courts to adjudicate disputes, and car jails to house automotive offenders? If so, what are the most common car crimes, and how are they enforced? The Cars universe is a treasure trove of unanswered questions and comedic potential.\r\n\r\nSo, as we reach the finish line of our deep dive into Pixar's Cars, it's clear that the film is more than just a simple tale of a hotshot race car learning the value of friendship and humility. It's also a wild, head-scratching journey through a world where cars rule the roost, and logic takes a permanent vacation. Buckle up, grab some popcorn, and enjoy the ride as we laugh our way through the absurdity that is Pixar's Cars. And remember, the next time you're stuck in traffic, take solace in the fact that at least your car isn't judging your driving skills – or is it?";

        content = content.Replace("\r", "");

        content = content.Replace("reader", "listener");

        content += subscribeDisclaimer;

        string[] dialogues = content.Split(new string[] { "\n\n" }, StringSplitOptions.None);

        var inputFiles = new string[dialogues.Length];

        var basePath = $"C:\\Users\\maxhe\\OneDrive\\Pictures\\Saved Pictures\\MovieFun\\";

        var outputFile = $"{basePath}{topic}.mp4";
        var tonyImage = $"{basePath}AiFilmCritic.png";        
        var count = 1;

        foreach (var input in dialogues)
        {                     
            Console.WriteLine($"Part {count} of {dialogues.Length.ToString()}");          
            Console.WriteLine($"{input}\n");

            var audioFile = $"{basePath}review-{count}.wav";

            await TextToSpeech(input, "Tony", "cheerful", audioFile);

            var vidOutputFile = $"{basePath}review-{count}.mp4";
            
            FFMpeg.PosterWithAudio(tonyImage, audioFile, vidOutputFile);

            inputFiles[count - 1] = vidOutputFile;

            // delete the audio file once it is no longer needed
            File.Delete(audioFile);

            count++;
        }

        FFMpeg.Join(outputFile, inputFiles);

        // delete the inputfiles
        foreach (var file in inputFiles)
        {
            File.Delete(file);
        }

        // CombineWavFiles(inputFiles, outputFile);
    }

    public static async Task TextToSpeech(string text, string voiceName, string speechStyle, string audioFilePath)
    {
        var speechKey = "YourSpeechKey";
        var regionKey = "eastus";

        var speechConfig = SpeechConfig.FromSubscription(speechKey, regionKey);

        //speechConfig.SpeechSynthesisVoiceName = "en-US-JennyNeural";

        var ssml = $"<speak xmlns=\"http://www.w3.org/2001/10/synthesis\" xmlns:mstts=\"http://www.w3.org/2001/mstts\" xmlns:emo=\"http://www.w3.org/2009/10/emotionml\" version=\"1.0\" xml:lang=\"en-US\">\r\n  <voice name=\"en-US-{voiceName}Neural\">\r\n    <s/>\r\n    <mstts:express-as style=\"{speechStyle}\">{text} ,</mstts:express-as>\r\n    <s/>\r\n  </voice></speak>";

        using (var speechSynthesizer = new SpeechSynthesizer(speechConfig))
        {
            var speechResult = await speechSynthesizer.SpeakSsmlAsync(ssml);

            if (speechResult.Reason == ResultReason.SynthesizingAudioCompleted)
            {
                using var stream = AudioDataStream.FromResult(speechResult);
                await stream.SaveToWaveFileAsync(audioFilePath);
                stream.Dispose();
            }
            else
            {
                Console.WriteLine($"Speech synthesis failed. Reason: {speechResult.Reason}");
                throw new InvalidOperationException($"Speech synthesis failed. Reason: {speechResult.Reason}");
            }
        }
    }
}