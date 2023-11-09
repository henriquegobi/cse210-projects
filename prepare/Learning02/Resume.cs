namespace Learning02
{
    public class Resume
    {
        public String _name;
        public List<Job> _jobs = new List<Job>();

        public void DisplayResume()
        {
            Console.WriteLine(_name);
            Console.Write("Jobs:");

            foreach (Job job in _jobs)
            {
                job.Display();
            }
        }
    }
}