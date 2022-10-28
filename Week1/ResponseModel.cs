namespace Week1
{
    public sealed class ResponseModel
    {
        public string slackUsername { get; private set; }   
        public bool backend { get; private set; }
        public int age { get; private set; }
        public string bio { get; private set; }

        private static readonly ResponseModel Instance = new ResponseModel();

        private ResponseModel() 
        {
                slackUsername = "David Okeke";
                backend = true;
                age = 24;
                bio = "A software engineer focused on writing back-end code. I use the .NET stack and most recently django " +
                "to create RESTful Api and Web applications. I enjoy writing clean-code, focusing on " +
                "predictable styling and design patterns, crafting reusable libraries, writing great unit tests." +
                "I also enjoy data structures and algorithms";
        }

        public static  ResponseModel ResponseModelInstance
        {
            get{ return Instance; }

        }

    }
}
