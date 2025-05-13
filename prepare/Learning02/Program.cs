using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job("Microsoft", "Software Engineer", 2019, 2022);
        Job job2 = new Job("Apple", "Manager", 2022, 2023);

        Resume resume1 = new Resume("Allison Rose", new List<Job> { job1, job2 });

        resume1.Display();
    }
}