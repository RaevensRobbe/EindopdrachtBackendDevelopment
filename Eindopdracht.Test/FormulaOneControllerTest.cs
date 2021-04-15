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

namespace Eindopdracht.Test
{
    public class FormulaOneControllerTest : IClassFixture<WebApplicationFactory<EindopdrachtBackendDevelopment.Startup>>
    {
        public HttpClient Client { get; set; }
        
        public FormulaOneControllerTest(WebApplicationFactory<EindopdrachtBackendDevelopment.Startup> fixture)
        {
            Client = fixture.CreateClient();
        }

        [Fact]
        public async Task Get_Drivers_Should_Return_Ok()
        {
            var response = await Client.GetAsync("/drivers/");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Get_Driver_Should_Return_Ok()
        {
            var response = await Client.GetAsync("/driver/1");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

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
    }
}
