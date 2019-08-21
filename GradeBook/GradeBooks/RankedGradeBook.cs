using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook:BaseGradeBook
    {
        public RankedGradeBook(string name):base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            int studentCount = Students.Count;
            if (studentCount < 5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            }

            int rank = 0;
            foreach(Student student in this.Students)
            {
                if (averageGrade < student.AverageGrade)
                {
                    rank++;
                }
            }
           int rankSize = studentCount / 5;
           int percentile = rank/rankSize;
            switch(percentile)
            {
                case 0:
                    return ('A');
                case 1:
                    return ('B');
                case 2:
                    return ('C');
                case 3:
                    return ('D');
            }
            return ('F');
        }

        public override void CalculateStatistics()
        {
            int studentCount = Students.Count;
            if (studentCount < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            int studentCount = Students.Count;
            if (studentCount < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStudentStatistics(name);
        }
    }
}
