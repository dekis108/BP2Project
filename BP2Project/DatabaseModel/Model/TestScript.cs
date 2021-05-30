using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel.Model
{
    public class TestScript
    {
        Random rand = new Random(Guid.NewGuid().GetHashCode());

        public TestScript() {}

        public void Run()
        {
            using (var db = new ProjectModelContainer())
            {
                //generate 10 of each
                for (int i = 0; i < 10; ++i)
                {
                    GeneratePoslovniProstor(db, "PP" + i);
                    GenerateTim(db, "T" + i);
                    GenerateProgramer(db, "PR" + i);
                }


                //assign all programers to random teams
                for (int i = 0; i < 10; ++i)
                {
                    AddProgramerToTeam(db, "PR" + i, "T" + rand.Next(0,10));
                }

                //assign a team lead to every team that has atleast 1 member
                AssignTeamLeads(db);

                db.SaveChanges();
                Console.WriteLine("Success");
            }
        }

        private void AssignTeamLeads(ProjectModelContainer db)
        {
            var teams = db.Timovi.Where(x => x.Programeri.Count > 0);
            
            foreach(Tim team in teams)
            {
                var programeri = team.Programeri.ToList();
                team.VodjaTima = programeri.First();
            }
        }

        private void AddProgramerToTeam(ProjectModelContainer db, string programerId, string teamId)
        {
            Programer prog = (Programer)db.Zaposleni.Find(programerId);
            prog.ClanTima = db.Timovi.Find(teamId);

            db.SaveChanges();   
        }

        private void GenerateProgramer(ProjectModelContainer db, string programerID)
        {
            Programer newProgramer = new Programer
            {
                Id = programerID,
                D_ZAP = DateTime.Now,
                O_PROD = 13,
                PLAT = 13000
            };

            db.Zaposleni.Add(newProgramer);
        }

        private void GenerateTim(ProjectModelContainer db, string teamId)
        {
            Tim tim = new Tim
            {
                ST = teamId,
                PR = "Research&Development",
            };

            db.Timovi.Add(tim);  
        }

        private void GeneratePoslovniProstor(ProjectModelContainer db, string roomId)
        {
            PoslovniProstor poslovniProstor = new PoslovniProstor
            {
                SP = roomId,
                DIM = 80.0M,
                BRM = 10
            };

            db.PoslovniProstori.Add(poslovniProstor);
        }

    }
}
