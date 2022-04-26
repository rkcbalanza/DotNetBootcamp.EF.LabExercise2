using EntityFramework.LabExercise2.Data;
using EntityFramework.LabExercise2.Repositories;
using EntityFramework.LabExercise2.Models;
using System;
using System.Collections.Generic;

namespace EntityFramework.LabExercise2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConfigurationHelper configurationHelper = ConfigurationHelper.Instance();

            var dbConnectionString = configurationHelper.GetProperty<string>("DbConnectionString");

            Console.Write("Enter Employee Code:");
            string employeeCode = Console.ReadLine();

            using (RecruitmentContext context = new RecruitmentContext(dbConnectionString))
            {
                EmployeeGenericRepository employeeGenericRepository = new EmployeeGenericRepository(context);

                try
                {

                    Employee employeeBasicInfo = employeeGenericRepository.FindByEmployeeCode(employeeCode);
                    Console.WriteLine($"~ Employee Code: {employeeBasicInfo.CEmployeeCode}");
                    Console.WriteLine($"~ First Name: {employeeBasicInfo.VFirstName}");
                    Console.WriteLine($"~ Last Name: {employeeBasicInfo.VLastName}");

                    PositionGenericRepository positionGenericRepository = new PositionGenericRepository(context);
                    Position employeePosition = positionGenericRepository.FindByCode(employeeBasicInfo.CCurrentPosition);
                    Console.WriteLine($"~ Position: {employeePosition.VDescription}");

                    Console.WriteLine("\n");

                    AnnualSalaryGenericRepository annualSalaryGenericRepository = new AnnualSalaryGenericRepository(context);
                    IEnumerable<AnnualSalary> employeeAnnualSalary = annualSalaryGenericRepository.FindByEmployeeCode(employeeCode);
                    Console.WriteLine("~ Annual Salary");
                    foreach (AnnualSalary annualSalary in employeeAnnualSalary)
                    {
                        Console.WriteLine($"~~ {annualSalary.MAnnualSalary} ~~ {annualSalary.SiYear}");
                    }

                    Console.WriteLine("\n");

                    MonthlySalaryGenericRepository monthlySalaryGenericRepository = new MonthlySalaryGenericRepository(context);
                    IEnumerable<MonthlySalary> employeeMonthlySalary = monthlySalaryGenericRepository.FindByEmployeeCode(employeeCode);
                    Console.WriteLine("~ Monthly Salary");
                    foreach (MonthlySalary monthlySalary in employeeMonthlySalary)
                    {
                        Console.WriteLine($"~~ {monthlySalary.MMonthlySalary} ~~ {monthlySalary.DPayDate} ~~ {monthlySalary.MReferralBonus}");
                    }

                    Console.WriteLine("\n");

                    CandidateSkillGenericRepository candidateSkillGenericRepository = new CandidateSkillGenericRepository(context);
                    SkillGenericRepository skillGenericRepository = new SkillGenericRepository(context);
                    IEnumerable<CandidateSkill> candidateSkills = candidateSkillGenericRepository.FindSkillByCandidateCode(employeeBasicInfo.CCandidateCode);
                    Console.WriteLine($"~ Skills");
                    foreach (CandidateSkill candidateSkill in candidateSkills)
                    {
                        Skill skill = skillGenericRepository.FindBySkillCode(candidateSkill.CSkillCode);
                        Console.WriteLine($"~~ {skill.VSkill}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

        }
    }
}
