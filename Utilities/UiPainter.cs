using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Text;
using CoreTest.Entities;
using static System.Console;

namespace CoreTest.Utilities
{
  public static class UiPainter
  {
    public static void PaintMainUi()
    {
      PaintTitle("USER MANAGEMENT SYSTEM");
      PaintTitle("CHOOSE WHAT TO DO");
      WriteLine("1: ADD\n2: EDIT\n3: DELETE\n4: SEARCH\n5: EXIT");
    }

    private static void PaintTitle(string title)
    {
      var fixedSize = title.Length + 18;
      PaintLine(fixedSize);
      WriteLine($"-------- {title.ToUpper()} ----------");
    }

    private static void PaintLine(int fixedSize = 10)
    {
      var line = "".PadLeft(fixedSize, '-');
      WriteLine($"*{line}*");
    }

    public static void PaintAddTitle()
    {
      PaintTitle("ADD A NEW USER");
    }
    public static void PaintAddFirstName()
    {
      WriteLine("INPUT USERS FORENAME");
    }

    public static void PaintAddLastName()
    {
      PaintAddTitle();
      WriteLine("INPUT USERS LAST NAME");
    }

    public static void PaintAddMoLastName()
    {
      PaintAddTitle();
      WriteLine("INPUT USERS MOTHERS LAST NAME");
    }
    
    public static void PaintAddBirthDate()
    {
      PaintAddTitle();
      WriteLine("INPUT USERS BIRTHDATE MM/DD/YYYY");
    }

    public static void PaintSetMaStatus()
    {
      PaintAddTitle();
      WriteLine("SELECT A MARITAL STATUS");
      WriteLine("1: SINGLE\n2: MARRIED");
    }
    
    public static void PaintSetBloodType()
    {
      PaintAddTitle();
      WriteLine("SELECT A BLOOD TYPE");
      WriteLine("1: ORH+\n2: ORH-\n3: BRH+\n4: BRH-\n5: ARH+\n6: ARH-\n7: ABRH+\n8: ABRH-");
    }
    
    public static void PaintSetGender()
    {
      PaintAddTitle();
      WriteLine("SELECT GENDER");
      WriteLine("1: FEMALE\n2: MALE\n3: NONBINARY");
    }
    
    public static void PaintEdit()
    {
      PaintTitle("EDIT A USER");
      WriteLine("INPUT NEW VALUE");
    }

    public static void PaintDelete()
    {
      PaintTitle("DELETE A USER");
      WriteLine("INPUT USER NAME");
    }

    public static void PaintSearch()
    {
      PaintTitle("SEARCH A USER");
      WriteLine("SELECT A SEARCH OPTION");
      WriteLine("1: BY FIRST NAME\n2: BY LAST NAME\n" +
                "3: BY MOTHERS LAST NAME\n4: BY BIRTHDATE(MM/DD/YYYY)\n" +
                "5: BY MARITAL STATUS\n6: BY BLOOD TYPE\n7: BY GENDER");
    }

    public static void PaintResult(IEnumerable query)
    {
      Clear();
      int age = 0;
      PaintTitle("RESULTS");
      foreach (var result in query)
      {
        var answer = (User) result;
        age = DateTime.Now.Year - answer.Birthdate.Year;
        if (DateTime.Now.DayOfYear < answer.Birthdate.DayOfYear)
          age = age - 1;
        WriteLine($"{answer.FirstName} {answer.LastName} {answer.MothersLastName} \n Age: {age}");
      }
    }
  }
}
