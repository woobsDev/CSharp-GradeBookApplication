using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            //The GetLetterGrade method returns a char and accepts a double named "averageGrade".
            //If there are less than 5 students throw an InvalidOperationException. (Ranked - grading requires a minimum of 5 students to work)
            //Return 'F' at the end of the method.
            List<double> gradeList = new List<double>();
            int TwentyPercentIndex, FortyPercentIndex, SixtyPercentIndex, EightyPercentIndex;


            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked - grading requires a minimum of 5 students to work");
            }

            foreach (Student student in Students)
            {
                gradeList.Add(student.AverageGrade);
            }

            TwentyPercentIndex = (int)Math.Round(.8 * (gradeList.Count));
            FortyPercentIndex = (int)Math.Round(.6 * (gradeList.Count));
            SixtyPercentIndex = (int)Math.Round(.4 * (gradeList.Count));
            EightyPercentIndex = (int)Math.Round(.2 * (gradeList.Count));
            gradeList.Sort();

            //If the input grade is in the top 20% of the class the method should return an 'A'.

            if (averageGrade >= gradeList[TwentyPercentIndex])
            {
                return 'A';
            }
            else if(averageGrade >= gradeList[FortyPercentIndex] && averageGrade < gradeList[TwentyPercentIndex])
            {
                return 'B';
            }
            else if (averageGrade >= gradeList[SixtyPercentIndex] && averageGrade < gradeList[FortyPercentIndex])
            {
                return 'C';
            }
            else if (averageGrade >= gradeList[EightyPercentIndex] && averageGrade < gradeList[SixtyPercentIndex])
            {
                return 'D';
            }
            else
            {
                return 'F';
            }
        }

		public override void CalculateStatistics()
		{
			if(Students.Count < 5)
			{
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
			}
            else
			{
                base.CalculateStatistics();
			}
		}

		public override void CalculateStudentStatistics(string name)
		{
            if(Students.Count < 5)
			{
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
			}
            else
			{
                base.CalculateStudentStatistics(name);
            }
		}

	}
}
