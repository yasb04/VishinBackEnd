//*****************************************************************************************
//*                                                                                       *
//* This is an auto-generated file by Microsoft ML.NET CLI (Command-Line Interface) tool. *
//*                                                                                       *
//*****************************************************************************************

using System;
using FraudDetectionModel.Model;

namespace FraudDetectionModel.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create single instance of sample data from first line of dataset for model input
            ModelInput sampleData = new ModelInput()
            {
                Text = @"Swish: Vi har noterat en misstänkt betalning på 4500 kr. Klicka här för att avbryta: swish-sakerhet.com/avbryt",
                Type = @"SMS",
            };

            // Make a single prediction on the sample data and print results
            var predictionResult = ConsumeModel.Predict(sampleData);

            Console.WriteLine("Using model to make single prediction -- Comparing actual Fraud_value with predicted Fraud_value from sample data...\n\n");
            Console.WriteLine($"Text: {sampleData.Text}");
            Console.WriteLine($"Type: {sampleData.Type}");
            Console.WriteLine($"\n\nPredicted Fraud_value value {predictionResult.Prediction} \nPredicted Fraud_value scores: [{String.Join(",", predictionResult.Score)}]\n\n");
            Console.WriteLine("=============== End of process, hit any key to finish ===============");
            Console.ReadKey();
        }
    }
}
