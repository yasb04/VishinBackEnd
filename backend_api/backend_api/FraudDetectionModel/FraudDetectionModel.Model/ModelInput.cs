//*****************************************************************************************
//*                                                                                       *
//* This is an auto-generated file by Microsoft ML.NET CLI (Command-Line Interface) tool. *
//*                                                                                       *
//*****************************************************************************************

using Microsoft.ML.Data;

namespace FraudDetectionModel.Model
{
    public class ModelInput
    {
        [ColumnName("Text"), LoadColumn(0)]
        public string Text { get; set; }


        [ColumnName("fraud_value"), LoadColumn(1)]
        public string Fraud_value { get; set; }


        [ColumnName("type"), LoadColumn(2)]
        public string Type { get; set; }


    }
}
