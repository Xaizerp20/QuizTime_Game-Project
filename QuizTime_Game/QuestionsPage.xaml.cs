using System.Timers;
using Timer = System.Timers.Timer;

namespace QuizTime_Game;

public partial class QuestionsPage : ContentPage
{

    int count = 0;
    public static int secondsCount = 0;

    public static List<Question> Questions = new List<Question>();

    Button[] answerButtonsList = new Button[4];


    Timer timer = new Timer(1000);

	public QuestionsPage()
	{
		InitializeComponent();


        //Add question to list
        Questions.Add(CreateQuestion("What is the chemical symbol for table salt?", "O2", "CO2", "H2O", "NaCl"));
        Questions.Add(CreateQuestion("Which gas do plants use for photosynthesis?", "Oxygen", "Carbon dioxide", "Nitrogen", "Hydrogen"));
        Questions.Add(CreateQuestion("What is the largest planet in our solar system?", "Venus", "Mars", "Jupiter", "Saturn"));
        Questions.Add(CreateQuestion("What is the process by which plants make their own food?", "Respiration", "Transpiration", "Photosynthesis", "Fermentation"));
        Questions.Add(CreateQuestion("Which gas is responsible for the Earth's ozone layer?", "Oxygen", "Carbon dioxide", "Methane", "Ozone"));
        Questions.Add(CreateQuestion("What is the unit of measurement for electrical resistance?", "Ohm", "Volt", "Ampere", "Watt"));
        Questions.Add(CreateQuestion("Which scientist developed the theory of general relativity?", "Isaac Newton", "Albert Einstein", "Galileo Galilei", "Nikola Tesla"));
        Questions.Add(CreateQuestion("What is the smallest prime number?", "1", "2", "3", "5"));
        Questions.Add(CreateQuestion("What is the process by which liquid water turns into water vapor?", "Evaporation", "Condensation", "Sublimation", "Melting"));
        Questions.Add(CreateQuestion("Which gas do plants release during photosynthesis?", "Oxygen", "Carbon dioxide", "Nitrogen", "Hydrogen"));


        //manage timer for Questions
        timer.Elapsed += TimerElpased;
        timer.Enabled = true;
        timer.AutoReset = true;
        timer.Start();



        answerButtonsList = new Button[] { Answertxt1, Answertxt2, Answertxt3, Answertxt4 };


        GenerateQuestion(this, EventArgs.Empty);
    }

    //this method add question to list
    public static Question CreateQuestion(string description, params string[] answers)
    {
        return new Question
        {
            Description = description,
            Answers = answers
        };
    }

    public void Onclick_Answer1(object sender, EventArgs e)
    {
        Answertxt1.BackgroundColor = Colors.Green;
        Answertxt1.TextColor = Colors.White;

    }

    public void Onclick_Answer2(object sender, EventArgs e)
    {
        Answertxt1.BackgroundColor = Colors.Green;
        Answertxt2.TextColor = Colors.White;
    }

    public void Onclick_Answer3(object sender, EventArgs e)
    {
        Answertxt1.BackgroundColor = Colors.Green;
        Answertxt3.TextColor = Colors.White;
    }

    public void Onclick_Answer4(object sender, EventArgs e)
    {
        Answertxt1.BackgroundColor = Colors.Green;
        Answertxt4.TextColor = Colors.White;
    }


    //method to Change question text UI
    public void GenerateQuestion(object sender, EventArgs e)
    {

        Dispatcher.Dispatch((Action)(() =>
        {

            Questiontxt.Text = Questions[count].Description; //TODO: CORRECT WHEN COUNTER GO TO MAXIMUM QUESTIONS

            Answertxt1.Text = Questions[count].Answers[0];
            Answertxt2.Text = Questions[count].Answers[1];
            Answertxt3.Text = Questions[count].Answers[2];
            Answertxt4.Text = Questions[count].Answers[3];

        }));


        count++;
    }


    //method to print elpased time betwen questions
    public void TimerElpased(object sender, ElapsedEventArgs e)
    {
        secondsCount++;
        Dispatcher.Dispatch((Action)(() => {

            ProgressButton.Text = secondsCount.ToString();



            if (secondsCount == 5) //if elpased time is 10 seconds, change question
            {
                GenerateQuestion(this, EventArgs.Empty);
                secondsCount = 0;


                foreach (var btn in answerButtonsList)
                {
                    btn.TextColor = Colors.Blue;
                    btn.BackgroundColor = Colors.White;
                }
            }

        })); 


    }
}

public class Question
{
    public string Description { get; set; }
    public string[] Answers { get; set; } = new string[4];
}
