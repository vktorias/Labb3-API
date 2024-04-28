using Labb3_API.Data;
using Labb3_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Labb3_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
             ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddAuthorization();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            //PERSONER
            app.MapGet("/peoples", async (ApplicationDbContext context) =>
            {
                var peoples = await context.Peoples.ToListAsync();
                if (peoples == null || !peoples.Any())
                {
                    return Results.NotFound("No peoples found.");
                }
                return Results.Ok(peoples);
            });

            app.MapPost("/peoples", async (People people, ApplicationDbContext context) =>
            {
                context.Peoples.Add(people);
                await context.SaveChangesAsync();
                return Results.Created($"/peoples/{people.PeopleId}", people);
            }
            );

            // Endpoint för att hämta alla intressen för en specifik person
            app.MapGet("/peoples/{peopleId}/interests", async (int peopleId, ApplicationDbContext context) =>
            {
                // Hitta personen med det angivna personId
                var person = await context.Peoples.FindAsync(peopleId);
                if (person == null)
                {
                    return Results.NotFound("Could not find the specified person");
                }

                // Hämta kopplingar mellan personen och intressen
                var peopleInterests = await context.PeopleInterests
                                                    .Where(pi => pi.PeopleId == peopleId)
                                                    .ToListAsync();

                // Lista för att lagra intressen med tillhörande personens namn
                var interests = new List<object>();

                // Loopa igenom kopplingarna och hämta intressen
                foreach (var peopleInterest in peopleInterests)
                {
                    var interest = await context.Interests.FindAsync(peopleInterest.InterestId);
                    if (interest != null)
                    {
                        var response = new
                        {
                            PersonName = person.PeopleName,
                            InterestTitle = interest.Title,
                            InterestDescription = interest.Description
                        };
                        interests.Add(response);
                    }
                }

                if (!interests.Any())
                {
                    return Results.NotFound("Could not find any interests for the specified person");
                }

                return Results.Ok(interests);
            });

            //INTRESSEN
            app.MapGet("/interests", async (ApplicationDbContext context) =>
            {
                var interest = await context.Interests.ToListAsync();
                if (interest == null || !interest.Any())
                {
                    return Results.NotFound("No interests found.");
                }
                return Results.Ok(interest);
            });

            app.MapPost("/interests", async (Interest interest, ApplicationDbContext context) =>
            {
                context.Interests.Add(interest);
                await context.SaveChangesAsync();
                return Results.Created($"/interests/{interest.InterestId}", interest);
            }
            );

            // Endpoint för att koppla en person till ett nytt intresse
            app.MapPost("/peoples/{peopleId}/interests", async (int peopleId, Interest interest, ApplicationDbContext context) =>
            {
                // Hämta personen från databasen inklusive dess namn
                var person = await context.Peoples
                                        .Where(p => p.PeopleId == peopleId)
                                        .FirstOrDefaultAsync();

                if (person == null)
                {
                    return Results.NotFound("Could not find the specified person");
                }

                // Lägg till det nya intresset i databasen
                context.Interests.Add(interest);
                await context.SaveChangesAsync();

                // Skapa en ny post i tabellen PeopleInterests för att koppla personen till det nya intresset
                var peopleInterest = new PeopleInterest
                {
                    PeopleId = peopleId,
                    InterestId = interest.InterestId
                };

                context.PeopleInterests.Add(peopleInterest);
                await context.SaveChangesAsync();

                // Skapa ett objekt som innehåller både personens namn och intresset
                var response = new
                {
                    PersonName = person.PeopleName,
                    Interest = interest
                };

                return Results.Created($"/peoples/{peopleId}/interests/{interest.InterestId}", response);
            });

            // Endpoint för att lägga till ett befintligt intresse på en befintlig person
            app.MapPost("/people/{peopleId}/interests/{interestId}", async (int peopleId, int interestId, ApplicationDbContext context) =>
            {
                // Kontrollera om den angivna personen och intresset finns i databasen
                var person = await context.Peoples.FindAsync(peopleId);
                var interest = await context.Interests.FindAsync(interestId);

                if (person == null || interest == null)
                {
                    return Results.NotFound("Person or interest not found.");
                }

                // Kontrollera om personen redan har det angivna intresset
                var existingInterest = await context.PeopleInterests
                                                    .Where(pi => pi.PeopleId == peopleId && pi.InterestId == interestId)
                                                    .FirstOrDefaultAsync();

                if (existingInterest != null)
                {
                    return Results.Conflict("Person already has this interest.");
                }

                // Skapa en ny post i tabellen PeopleInterests för att koppla personen till det angivna intresset
                var peopleInterest = new PeopleInterest
                {
                    PeopleId = peopleId,
                    InterestId = interestId
                };

                context.PeopleInterests.Add(peopleInterest);
                await context.SaveChangesAsync();

                return Results.Created($"/people/{peopleId}/interests/{interestId}", peopleInterest);
            });

            //LÄNKAR
            app.MapGet("/links", async (ApplicationDbContext context) =>
            {
                var interestLinks = await context.Links.ToListAsync();
                if (interestLinks == null || !interestLinks.Any())
                {
                    return Results.NotFound("No interests found.");
                }
                return Results.Ok(interestLinks);
            });

            app.MapPost("/links", async (Link link, ApplicationDbContext context) =>
            {
                context.Links.Add(link);
                await context.SaveChangesAsync();
                return Results.Created($"/interests/{link.LinkId}", link);
            });

            // Endpoint för att hämta alla länkar för en specifik person
            app.MapGet("/peoples/{peopleId}/links", async (int peopleId, ApplicationDbContext context) =>
            {
                // Hitta personen med det angivna personId
                var people = await context.Peoples.FindAsync(peopleId);
                if (people == null)
                {
                    return Results.NotFound("Could not find the specified person");
                }

                // Hämta personintresseposter för den angivna personen
                var peopleInterests = await context.PeopleInterests
                                                    .Where(pi => pi.PeopleId == peopleId)
                                                    .ToListAsync();

                // Lista för att lagra länkar med tillhörande personens namn
                var links = new List<object>();

                // Loopa igenom personintresseposter och hämta länkar
                foreach (var peopleInterest in peopleInterests)
                {
                    var interestLinks = await context.Links
                                                    .Where(link => link.InterestId == peopleInterest.InterestId)
                                                    .ToListAsync();
                    foreach (var link in interestLinks)
                    {
                        var response = new
                        {
                            PersonName = people.PeopleName,
                            LinkUrl = link.Website,
                        };
                        links.Add(response);
                    }
                }

                if (!links.Any())
                {
                    return Results.NotFound("Could not find any links for the specified person");
                }

                return Results.Ok(links);
            });


            app.Run();
        }
    }
}