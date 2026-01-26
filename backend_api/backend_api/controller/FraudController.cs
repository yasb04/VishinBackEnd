namespace backend_api.Data.controller;
using Microsoft.AspNetCore.Mvc;
using FraudDetectionModel.Model;

    [ApiController]
    [Route("api/[controller]")]
    public class FraudController : ControllerBase
    {
        // Vi skapar en liten klass för att ta emot JSON-datan snyggt
        public class FraudRequest
        {
            public string Text { get; set; }
        }

        [HttpPost("check")]
        public IActionResult CheckFraud([FromBody] FraudRequest request)
        {
            // 1. Skapa input till AI:n
            // OBS: Kolla i filen FraudDetectionModel.consumption.cs vad propertyn heter.
            // Oftast heter den samma som rubriken i din CSV-fil (t.ex. "Text" eller "Col0").
            var input = new ModelInput
            {
                Text = request.Text 
            };

            // 2. Låt AI:n gissa (Predict)
            var result = ConsumeModel.Predict(input);

            // 3. Tolka svaret
            // I ML.NET brukar "1" betyda det vi tränade på (Fraud) och "0" betyder Safe.
            // PredictedLabel är det AI:n tror mest på.
            // Score är en lista med sannolikheter.
            
            bool isFraud = result.Prediction == "1";
            
            // Score[1] brukar vara sannolikheten för "1" (Fraud). 
            // Vi gör om det till procent (0.85 = 85%).
            float confidence = result.Score.Length > 1 ? result.Score[1] : 0;

            return Ok(new
            {
                IsFraud = isFraud,
                Confidence = $"{confidence * 100:0.0}%",
                Message = isFraud ? "VARNING: Detta ser ut som bedrägeri!" : "Detta ser säkert ut.",
                OriginalText = request.Text
            });
        }
    }
