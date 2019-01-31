using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BuffteksWebsite.Models
{
    public class DataSeeder
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(var context = new BuffteksWebsiteContext(serviceProvider.GetRequiredService<DbContextOptions<BuffteksWebsiteContext>>()))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                

                // CLIENTS
                if (context.Clients.Any())
                {
                    //leave, there is already data in the database
                    return; 
                }

                var clients = new List<Client>
                {
                    new Client { FirstName="Bob", LastName="Loblaw", CompanyName="Very Fancy Legal Firm", Email="BobLoblaw@VFLF.io", Phone="759-319-7327" },
                    new Client { FirstName="Charles", LastName="Boyle", CompanyName="NYPD", Email="cboyle@nypd.gov", Phone="212-578-4101" },
                    new Client { FirstName="Quigley", LastName="Quadomire", CompanyName="Self-Employed", Email="Quigley.Quadomire@gmail.com", Phone="421-145-2374" }
                };
                context.AddRange(clients);
                context.SaveChanges();


                // CLIENTS
                if (context.Members.Any())
                {
                    //leave, there is already data in the database
                    return; 
                }

                var members = new List<Member>
                {
                    new Member { FirstName="Gabrielle", LastName="Ashley", Major="CIS", Email="bgabrielle1@buffs.wtamu.edu", Phone="806-147-2348" },
                    new Member { FirstName="Kolton", LastName="Brock", Major="CIS", Email="kbrock@buffs.wtamu.edu", Phone="806-714-0561" },
                    new Member { FirstName="Tanner", LastName="Cude", Major="CIS", Email="tcude@buffs.wtamu.edu", Phone="806-631-1842" },
                    new Member { FirstName="John", LastName="Cunningham", Major="CIS", Email="jcunningham@buffs.wtamu.edu", Phone="806-591-5128" },
                    new Member { FirstName="Michael", LastName="Figueroa", Major="CIS", Email="mfigueroa@buffs.wtamu.edu", Phone="806-562-6321" },
                    new Member { FirstName="Drake", LastName="Fithen", Major="CIS", Email="dfithen@buffs.wtamu.edu", Phone="806-621-7637" },
                    new Member { FirstName="Trevor", LastName="Fleeman", Major="CIS", Email="tfleeman@buffs.wtamu.edu", Phone="806-970-3974" },
                    new Member { FirstName="Frank", LastName="Garcia", Major="CIS", Email="fgarcia@buffs.wtamu.edu", Phone="806-172-9045"},
                    new Member { FirstName="Jessica", LastName="Gutierrez", Major="CIS", Email="jgutierrez@buffs.wtamu.edu", Phone="806-173-9047"},
                    new Member { FirstName="Bradley", LastName="Holland", Major="CIS", Email="BHolland@buff.wtamu.edu", Phone="806-282-7443"},
                    new Member { FirstName="Yi Fu", LastName="Ji", Major="CIS", Email="Yji@buffs.wtamu.edu", Phone="702-164-3784"},
                    new Member { FirstName="Mara", LastName="Kinoff", Major="CIS", Email="mkinoff@buffs.wtamu.edu", Phone="702-190-0791"},
                    new Member { FirstName="Cesareo", LastName="Lona", Major="CIS", Email="clona1@buffs.wtamu.edu", Phone="346-784-4568"},
                    new Member { FirstName="Mason", LastName="McCollum", Major="CIS", Email="mmccollum@buffs.wtamu.edu", Phone="702-567-1468"},
                    new Member { FirstName="Quan", LastName="Nguyen", Major="CIS", Email="qnguyen1@buffs.wtamu.edu", Phone="702-154-7032"},
                    new Member { FirstName="Alexis", LastName="Oliva", Major="CIS", Email="aolivia1@buffs.wtamu.edu", Phone="783-702-0527"},
                    new Member { FirstName="Miguel", LastName="Reveles", Major="CIS", Email="mreveles1@buffs.wtamu.edu", Phone="782-764-2384"},
                    new Member { FirstName="Alexander", LastName="Roder", Major="CIS", Email="ajroder2@buffs.wtamu.edu", Phone="806-452-9706"},
                    new Member { FirstName="Robert", LastName="Taylor", Major="CIS", Email="rtaylor3@buffs.wtamu.edu", Phone="806-269-6024"},
                    new Member { FirstName="Matthew", LastName="Treadway", Major="CIS", Email="mtreadway@buffs.wtamu.edu", Phone="806-748-2063"},
                    new Member { FirstName="Trevor", LastName="Vieth", Major="CIS", Email="tvieth@buffs.wtamu.edu", Phone="806-238-5602"},
                    new Member { FirstName="Mark", LastName="Warren", Major="CIS", Email="mwarren2@buffs.wtamu.edu", Phone="806-387-2394"},
                    new Member { FirstName="Cory", LastName="Williams", Major="CIS", Email="cwilliams2@buffs.wtamu.edu", Phone="806-283-7568"},
                    new Member { FirstName="Aaron", LastName="Williamson", Major="CIS", Email="awilliamson1@buffs.wtamu.edu", Phone="806-345-0347"}

                };
                context.AddRange(members);
                context.SaveChanges();

                // PROJECTS
                if (context.Projects.Any())
                {
                    //leave, there is already data in the database
                    return; 
                }

                var projects = new List<Project>
                {
                    new Project { ProjectName="A New Microwave", ProjectDescription="Client wants help programming a new microwave OS" },
                    new Project { ProjectName="Tesla AutoPilot", ProjectDescription="Elon needs help rolling out AutoPilot v3.0" },
                    new Project { ProjectName="WTAMU OIT", ProjectDescription="The office of Information Technology needs some new devs" }
                };
                context.AddRange(projects);
                context.SaveChanges();

                //PROJECT ROSTER BRIDGE TABLE - THERE MUST BE PROJECTS AND PARTICIPANTS MADE FIRST
                if (context.ProjectRoster.Any())
                {
                    //leave, there is already data in the database
                    return; 
                }

                

                //quickly grab the recent records added to the DB to get the IDs
                var projectsFromDb = context.Projects.ToList();
                var clientsFromDb = context.Clients.ToList();
                var membersFromDb = context.Members.ToList();

                var projectroster = new List<ProjectRoster>
                {
                    //take the first project from above, the first client from above, and the first three students from above.
                    new ProjectRoster { ProjectID = projectsFromDb.ElementAt(0).ID.ToString(), 
                                        Project = projectsFromDb.ElementAt(0), 
                                        ProjectParticipantID = clientsFromDb.ElementAt(0).ID.ToString(),
                                        ProjectParticipant = clientsFromDb.ElementAt(0) },

                    new ProjectRoster { ProjectID = projectsFromDb.ElementAt(0).ID.ToString(), 
                                        Project = projectsFromDb.ElementAt(0), 
                                        ProjectParticipantID = membersFromDb.ElementAt(0).ID.ToString(),
                                        ProjectParticipant = membersFromDb.ElementAt(0) },

                    new ProjectRoster { ProjectID = projectsFromDb.ElementAt(0).ID.ToString(), 
                                        Project = projectsFromDb.ElementAt(0), 
                                        ProjectParticipantID = membersFromDb.ElementAt(1).ID.ToString(),
                                        ProjectParticipant = membersFromDb.ElementAt(1) },

                    new ProjectRoster { ProjectID = projectsFromDb.ElementAt(0).ID.ToString(), 
                                        Project = projectsFromDb.ElementAt(0), 
                                        ProjectParticipantID = membersFromDb.ElementAt(2).ID.ToString(),
                                        ProjectParticipant = membersFromDb.ElementAt(2) },                                        
                };
                context.AddRange(projectroster);
                context.SaveChanges();                

            }
        }
    }
}