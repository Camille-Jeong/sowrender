﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSVParser
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = File.ReadAllText(@"D:\workplace\c#\sowrender\sample_revenue.csv", Encoding.UTF8);

            List<SalesRowData> salesRowDataList = new List<SalesRowData>(1500);

            string[] lines = text.Split('\n');

            for (int index = 1; index < lines.Length; index++)
            {
                string[] chunks = lines[index].Split(',');

                if (chunks.Length > 19)
                {
                    chunks[5] = chunks[5] + ", " + chunks[6];

                    for (int i = 6; i < chunks.Length - 1; i++)
                    {
                        chunks[i] = chunks[i + 1];
                    }

                    chunks[5] = chunks[5].Substring(1, chunks[5].Length - 2);
                }

                SalesRowData salesRowData = new SalesRowData();

                try
                {
                salesRowData.rowId = uint.Parse(chunks[0]);
                salesRowData.amountUntaxed = double.Parse(chunks[1]);
                salesRowData.amountUsd = double.Parse(chunks[2]);
                salesRowData.company = chunks[3];
                salesRowData.countryName = chunks[4];
                salesRowData.customerName = chunks[5];
                salesRowData.dateMonth = uint.Parse(chunks[6]);
                salesRowData.dateOrder = new CSVParser.Date(chunks[7]);
                salesRowData.dateShipped = new CSVParser.Date(chunks[8]);
                salesRowData.discount = uint.Parse(chunks[9]);
                salesRowData.exchange_rate = uint.Parse(chunks[10]);
                salesRowData.model = chunks[11];
                salesRowData.orderNumber = chunks[12];
                salesRowData.priceUnit = double.Parse(chunks[13]);
                salesRowData.productId = uint.Parse(chunks[14]);
                salesRowData.productName = chunks[15];
                salesRowData.qty = uint.Parse(chunks[16]);
                salesRowData.status = chunks[17];
                salesRowData.zip = chunks[18];

                salesRowDataList.Add(salesRowData);
                } catch {
                    Console.WriteLine(index + " error");
                }
               
            }
            Console.ReadKey();
        }
    }
}