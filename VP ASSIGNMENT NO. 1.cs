using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp24
{
    class Student
    {
        public string stdId;
        public string stdName;
        public string stdSem;
        public double stdCgpa;
        public string stdDep;
        public string stdUni;
        public int n;

        //To Create Student Profile
        public static void profile(Student prof)
        {
            Console.WriteLine("Enter Number of Students:");
            prof.n = Convert.ToInt32(Console.ReadLine());
            StreamWriter SW = new StreamWriter(@"C:\\Users\\Anam Shafique\\Desktop\\Student.txt");
            for (int i = 0; i < prof.n; i++)
            {
                Console.WriteLine("\n\nStudent {0}:", i + 1);
                Console.WriteLine("Enter Your id:");
                prof.stdId = Console.ReadLine();
                SW.WriteLine(prof.stdId);
                Console.WriteLine("Enter Your Name:");
                prof.stdName = Console.ReadLine();
                SW.WriteLine(prof.stdName);
                Console.WriteLine("Enter Your Semester:");
                prof.stdSem = Console.ReadLine();
                SW.WriteLine(prof.stdSem);
                Console.WriteLine("Enter Your CGPA:");
                prof.stdCgpa = Convert.ToDouble(Console.ReadLine());
                SW.WriteLine(prof.stdCgpa);
                Console.WriteLine("Enter Your Department:");
                prof.stdDep = Console.ReadLine();
                SW.WriteLine(prof.stdDep);
                Console.WriteLine("Enter Your University:");
                prof.stdUni = Console.ReadLine();
                SW.WriteLine(prof.stdUni);
                SW.WriteLine(" ");
            }
            SW.Flush();
            SW.Close();
        }
        //To Search Student
        public static void search(Student prof)
        {
            Console.WriteLine("\tPress 1 to Search by Id\n\tPress 2 to Search by Name\n\tPress 3 to see List of all students\n");
            int choice1;
            choice1 = Convert.ToInt32(Console.ReadLine());
            //To Search Student By Id
            if (choice1 == 1)
            {
                string[] words = File.ReadAllText(@"C:\\Users\\Anam Shafique\\Desktop\\Student.txt").Split(' ');
                string std_Id;
                Console.WriteLine("Enter Student id:");
                std_Id = Console.ReadLine();
                bool condition = false;
                for (int i = 0; i < words.Length; i++)
                {
                    if (words[i].Contains(std_Id) == true)
                    {
                        Console.WriteLine(words[i] + " ");
                        condition = true;
                        break;
                    }
                    else
                    {
                        condition = false;
                        break;
                    }
                }
            }
            //To Search Student By Name
            if (choice1 == 2)
            {
                string[] words = File.ReadAllText(@"C:\\Users\\Anam Shafique\\Desktop\\Student.txt").Split(' ');
                string std_Name;
                Console.WriteLine("Enter Student Name:");
                std_Name = Console.ReadLine();
                bool condition = false;
                for (int i = 0; i < words.Length; i++)
                {
                    if (words[i].Contains(std_Name) == true)
                    {
                        Console.WriteLine(words[i] + " ");
                        condition = true;
                        break;
                    }
                    else
                    {
                        condition = false;
                        break;
                    }
                }
            }
            //To See List of All Students
            if (choice1 == 3)
            {
                string[] words = File.ReadAllText(@"C:\\Users\\Anam Shafique\\Desktop\\Student.txt").Split(' ');
                foreach (string word in words)
                    Console.WriteLine(word);
            }
        }
        //To List Top 3 of Class
        public static void topThree(Student prof)
        {
            double firstStd=0;
            double secondStd=0;
            double thirdStd=0;
            int first = 0;
            int second = 0;
            int third = 0;

            string[] lines = File.ReadAllLines(@"C:\\Users\\Anam Shafique\\Desktop\\Student.txt"); 
            string[] stId = new string[lines.Length];
            string[] stName = new string[lines.Length];
            string[] stSem = new string[lines.Length];
            double[] stCgpa= new double[lines.Length];
            string[] stDep = new string[lines.Length];
            string[] stUni = new string[lines.Length];
            for(int i=0; i<lines.Length; i=i+7)
            {
                stId[i] = lines[i];
                stName[i] = lines[i + 1];
                stSem[i] = lines[i + 2];
                stCgpa[i] =Convert.ToDouble(lines[i + 3]);
                stDep[i] = lines[i + 4];
                stUni[i] = lines[i + 5];
            }
            for (int i = 0; i < stCgpa.Length; i++)
            {
                if (stCgpa[i] > firstStd)
                {
                    thirdStd = secondStd;
                    secondStd = firstStd;
                    firstStd = stCgpa[i];
                    first = i;
                }
                else if (stCgpa[i] > secondStd)
                {
                    thirdStd = secondStd;
                    secondStd = stCgpa[i];
                    second = i;
                }
                else if (stCgpa[i] > thirdStd)
                {
                    thirdStd = stCgpa[i];
                    third = i;
                }
            }
            Console.WriteLine("First Student:");
            Console.WriteLine(stId[first] +"\t" + stName[first] + "\t" + stSem[first] + "\t" + stCgpa[first] + "\t" + stDep[first] + "\t" + stUni[first] + "\t" +"\n");
            Console.WriteLine("Second Student:");
            Console.WriteLine(stId[second] + "\t" + stName[second] + "\t" + stSem[second] + "\t" + stCgpa[second] + "\t" + stDep[second] + "\t" + stUni[second] + "\t" + "\n");
            Console.WriteLine("Third Student:");
            Console.WriteLine(stId[third] + "\t" + stName[third] + "\t" + stSem[third]  + "\t" + stCgpa[third] + "\t" + stDep[third] + "\t" + stUni[third] + "\t" + "\n");
        }
        //To Delete Student Record
        public static void delete(Student prof)
        {
            List<string> lines = File.ReadAllLines(@"C:\\Users\\Anam Shafique\\Desktop\\Student.txt").ToList();
            string std_Id;
            Console.WriteLine("Enter Student id:");
            std_Id = Console.ReadLine();
            for (int i = 0; i < lines.Count - 1; i++)
            {
                if (lines[i] == std_Id)
                {
                    for(int j = 0; j<6; j++)
                    {
                        lines.RemoveAt(0);
                    }
                }
            }
            File.WriteAllLines(@"C:\\Users\\Anam Shafique\\Desktop\\Student.txt", lines.ToArray());
        }
        //To Mark Attendance
        public static void markAttendance(Student prof)
        {
            string[] words = File.ReadAllText(@"C:\\Users\\Anam Shafique\\Desktop\\Student.txt").Split(' ');
            foreach (string word in words)
            Console.WriteLine(word);
            Console.WriteLine("Enter Number of Students to Mark Attendance:");
            prof.n = Convert.ToInt32(Console.ReadLine());
            StreamWriter SW = new StreamWriter(@"C:\\Users\\Anam Shafique\\Desktop\\PresentStudent.txt");
            for (int i = 0; i < prof.n; i++)
            {
                SW.WriteLine("Attendance:");
                Console.WriteLine("Present Student ID:");
                prof.stdId = Console.ReadLine();
                Console.WriteLine("Present Student Name:");
                prof.stdName= Console.ReadLine();
                SW.WriteLine("Present Students:");
                SW.WriteLine(prof.stdId);
                SW.WriteLine(prof.stdName);
                SW.WriteLine(" ");
                Console.WriteLine("Absent Student ID:");
                prof.stdId = Console.ReadLine();
                Console.WriteLine("Absent Student Name:");
                prof.stdName = Console.ReadLine();
                SW.WriteLine("Absent Students:");
                SW.WriteLine(prof.stdId);
                SW.WriteLine(prof.stdName);
                SW.WriteLine(" ");
            }
            SW.Flush();
            SW.Close();
        }
        //To View Attendance
        public static void viewAttendance(Student prof)
        {
            string[] words = File.ReadAllText(@"C:\\Users\\Anam Shafique\\Desktop\\PresentStudent.txt").Split(' ');
            foreach (string word in words)
                Console.WriteLine(word);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("\tPress 1 to Create Student Profile\n\tPress 2 to Search Student\n\tPress 3 to Delete Student Record\n\tPress 4 to list top 03 of Class\n\tPress 5 to Mark Student Attendance\n\tPress 6 to View Attendance\n");
            int choice;
            choice = Convert.ToInt32(Console.ReadLine());

                //To Create Student Profile
                if (choice == 1)
                {
                    Student prof1 = new Student();
                    profile(prof1);
                }
                //To Search Student
                else if (choice == 2)
                {
                    Student prof1 = new Student();
                    search(prof1);
                }
                //To Delete Student Record
                else if (choice == 3)
                {
                    Student prof1 = new Student();
                    delete(prof1);
                }
                //To List Top 3 of Class
                else if (choice == 4)
                {
                    Student prof1 = new Student();
                    topThree(prof1);
                }
                //To Mark Attendance
                else if (choice == 5)
                {
                    Student prof1 = new Student();
                    markAttendance(prof1);
                }
                //To View Attendance
                else if (choice == 6)
                {
                    Student prof1 = new Student();
                    viewAttendance(prof1);
                }
            Console.Read();
        }
    }
}







       