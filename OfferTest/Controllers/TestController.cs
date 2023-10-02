using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.DTO;
using OfferTest.Helpers;

namespace OfferTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly TestDbContext _DbContext;
        public TestController(TestDbContext Context)
        {
            _DbContext= Context;
        }
        [HttpGet(Name = "GetOfferDetails")]
        public List<OffersDTO> GetOfferDetails()
        { 
            DateTime startDate = new DateTime(2022, 12, 1);
            DateTime endDate = new DateTime(2024, 2, 1);
            //return _DbContext.Offers
            //    .Where(x => x.date >= startDate && x.date <= endDate)
            //    .Include(x=>x.Previous_Statuses.Where(s=>s.IsActive))
            //    .Include(x=>x.PossibleAmounts.Where(s=>s.IsActive))
            //        .ThenInclude(pa => pa.Amount)
            //    .Select(x=>new {
            //     OfferID = x.ID,
            //        OfferDate = x.date,
            //        CurrentStatus=x.Previous_Statuses.Select(a=>a.StatusID),
            //        CurrentAmount_Buyer_ID = x.PossibleAmounts.Select(c=>new { Amount_Value=c.Amount.Amount_Value , Buyer_ID=c.Amount.Buyer_ID })  ,
            //    })
            //    .ToList(); 
            return  
            (from TBLOffers in _DbContext.Offers.Where(x => x.date >= startDate && x.date <= endDate)
             join TBLPOSSAmnt in _DbContext.PossibleAmountss.Where(x => x.IsActive) on TBLOffers.ID equals TBLPOSSAmnt.OfferID into TBLPOSSAmntOut
             from TBLPOSSAmnt in TBLPOSSAmntOut.DefaultIfEmpty()
             join TBLAmnts in _DbContext.Amounts on TBLPOSSAmnt.AmountID equals TBLAmnts.ID
             join TBLByr in _DbContext.Buyers on TBLAmnts.Buyer_ID equals TBLByr.ID
             join TBLPREVStat in _DbContext.Previous_Statuses.Where(x => x.IsActive) on TBLOffers.ID equals TBLPREVStat.OfferID into TBLPREVStatOut
             from TBLPREVStat in TBLPREVStatOut.DefaultIfEmpty()
             join TblStats in _DbContext.Statuses on TBLPREVStat.StatusID equals TblStats.ID
             select new OffersDTO
             {
                 OfferID = TBLOffers.ID,
                 OfferDate = TBLOffers.date,
                 CurrentBuyer = TBLByr.Name,
                 CurrentAmount = TBLAmnts.Amount_Value,
                 CurrentStatusID = TblStats.ID
             }
            ).ToList();


        }

        [Route("TestThirdPartyAPI")]
        [HttpPost]
        public async Task<String> ThirdPartyAPI(int customerNumber) {
            int attempts = 10;
            for (int i = 1; i <= attempts; i++)
            {
                Random random = new Random();
                int targetNumber = random.Next(1000, 10000);
                try
                {
                    using (HttpClient httpClient = new HttpClient())
                    {
                        string apiUrl = "https://localhost:7267/lottery/play";
                        var requestContent = new StringContent($"{{\"customerNumber\": {customerNumber}}}", System.Text.Encoding.UTF8, "application/json");
                        HttpResponseMessage response = await httpClient.PostAsync(apiUrl, requestContent);
                        if (response.IsSuccessStatusCode)
                        {
                            string responseBody = await response.Content.ReadAsStringAsync();
                            int responseNumber = int.Parse(responseBody);
                            if (responseNumber == targetNumber)
                            {
                               return "Congratulations! You guessed the number!";
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            return "Unfortunately! Your Guess Was Wrong!";
        }

        [Route("GetAvailableKnightMovements")]
        [HttpGet]
        public GeneralErrors GetAvailableKnightMovements([FromQuery] Position Position) {
            if (!Position.IsInsideChessArea())
                return new GeneralErrors()
                {
                    Result = false,
                    Message = "Please Insert Available X and Y"
                };

            return new GeneralErrors()
            {
                Result = true,
                Message = "Places are : "+ Position.GetAvailablePositions()
            };

        }
     


    }
}
