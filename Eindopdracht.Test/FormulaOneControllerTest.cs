using System;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using FluentAssertions;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text;
using EindopdrachtBackendDevelopment.DTO;
using System.Diagnostics;
using EindopdrachtBackendDevelopment.Models;

namespace Eindopdracht.Test
{
    public class FormulaOneControllerTest : IClassFixture<WebApplicationFactory<EindopdrachtBackendDevelopment.Startup>>
    {
        public HttpClient Client { get; set; }
        
        public FormulaOneControllerTest(WebApplicationFactory<EindopdrachtBackendDevelopment.Startup> fixture)
        {
            Client = fixture.CreateClient();
        }

        //! API key nodig voor driver tests

        // [Fact]
        // public async Task Get_Drivers_Should_Return_Ok()
        // {
        //     var response = await Client.GetAsync("/drivers/");
        //     response.StatusCode.Should().Be(HttpStatusCode.OK);
        // }

        // [Fact]
        // public async Task Get_Driver_Should_Return_Ok()
        // {
        //     var response = await Client.GetAsync("/driver/1");
        //     response.StatusCode.Should().Be(HttpStatusCode.OK);
        // }

        //! TEAM tests
        [Fact]
        public async Task Get_Teams_Should_Return_Ok()
        {
            var response = await Client.GetAsync("/Teams/");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
        
        [Fact]
        public async Task Get_Team_Should_Return_Ok()
        {
            var response = await Client.GetAsync("/Team/1");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
        
        [Fact]
        public async Task Get_Team_Per_Country_Should_Return_Ok()
        {
            var response = await Client.GetAsync("/Teams/Italy");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Add_Team_Should_Return_Ok()
        {
            var team = new Team(){
                TeamName = "Test Team",
                Location = "Test land"
            };

            string json = JsonConvert.SerializeObject(team);
            Debug.WriteLine(json);
            var response = await Client.PostAsync("/team", new StringContent(json,Encoding.UTF8, "application/json"));
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var createdTeam = JsonConvert.DeserializeObject<Team>(await response.Content.ReadAsStringAsync());
            Assert.NotNull(createdTeam);
            Assert.Equal<string>("Test Team", createdTeam.TeamName);
        }

        //! Sponsor tests
        [Fact]
        public async Task Add_Sponsor_Should_Return_Ok()
        {
            var sponsor = new SponsorDTO(){
                SponsorName = "Test sponsor",
                Team = new List<int>(1)
            };

            string json = JsonConvert.SerializeObject(sponsor);
            Debug.WriteLine(json);
            var response = await Client.PostAsync("/sponsors", new StringContent(json,Encoding.UTF8, "application/json"));
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var createdSponsor = JsonConvert.DeserializeObject<SponsorDTO>(await response.Content.ReadAsStringAsync());
            Assert.NotNull(createdSponsor);
            Assert.Equal<string>("Test sponsor", createdSponsor.SponsorName);
        }

        [Fact]
        public async Task Get_Sponsors_Should_Return_Ok()
        {
            var response = await Client.GetAsync("/sponsors");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }        
    }
}
