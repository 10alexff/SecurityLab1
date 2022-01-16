﻿using Lab1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyApp
{
    public class Program
    {
        static string task1 = "7958401743454e1756174552475256435e59501a5c524e176f786517545e475f5245191772195019175e4317445f58" +
            "425b531743565c521756174443455e595017d5b7ab5f525b5b58174058455b53d5b7aa175659531b17505e41525917435f52175c524e175e4" +
            "417d5b7ab5c524ed5b7aa1b174f584517435f5217515e454443175b524343524517d5b7ab5fd5b7aa17405e435f17d5b7ab5cd5b7aa1b17435" +
            "f5259174f584517d5b7ab52d5b7aa17405e435f17d5b7ab52d5b7aa1b17435f525917d5b7ab5bd5b7aa17405e435f17d5b7ab4ed5b7aa1b17565" +
            "95317435f5259174f58451759524f4317545f564517d5b7ab5bd5b7aa17405e435f17d5b7ab5cd5b7aa175650565e591b17435f525917d5b7ab58d" +
            "5b7aa17405e435f17d5b7ab52d5b7aa1756595317445817585919176e5842175a564e17424452175659175e5953524f1758511754585e59545e53525" +
            "954521b177f565a5a5e595017535e4443565954521b177c56445e445c5e17524f565a5e5956435e58591b17444356435e44435e54565b1743524443441" +
            "7584517405f564352415245175a52435f5853174e5842175152525b174058425b5317445f584017435f52175552444317455244425b4319";
        static string task2 = "G0IFOFVMLRAPI1QJbEQDbFEYOFEPJxAfI10JbEMFIUAAKRAfOVIfOFkYOUQFI15ML1kcJFUeYhA4IxAeKVQZL1VMOFg" +
           "JbFMDIUAAKUgFOElMI1ZMOFgFPxADIlVMO1VMO1kAIBAZP1VMI14ANRAZPEAJPlMNP1VMIFUYOFUePxxMP19MOFgJbFsJNUMcLVMJbFkfbF8C" +
           "IElMfgZNbGQDbFcJOBAYJFkfbF8CKRAeJVcEOBANOUQDIVEYJVMNIFwVbEkDORAbJVwAbEAeI1INLlwVbF4JKVRMOF9MOUMJbEMDIVVMP18eOB" +
           "ADKhALKV4JOFkPbFEAK18eJUQEIRBEO1gFL1hMO18eJ1UIbEQEKRAOKUMYbFwNP0RMNVUNPhlAbEMFIUUALUQJKBANIl4JLVwFIldMI0JMK0IN" +
           "KFkJIkRMKFUfL1UCOB5MH1UeJV8ZP1wVYBAbPlkYKRAFOBAeJVcEOBACI0dAbEkDORAbJVwAbF4JKVRMJURMOF9MKFUPJUAEKUJMOFgJbF4JNERM" +
           "I14JbFEfbEcJIFxCbHIJLUJMJV5MIVkCKBxMOFgJPlWOzKkfbF4DbEMcLVMJPx5MRlgYOEAfdh9DKF8PPx4LI18LIFVCL18BY1QDL0UBKV4YY1RDfX" +
           "g1e3QAYQUFOGkof3MzK1sZKXIaOnIqPGRYD1UPC2AFHgNcDkMtHlw4PGFDKVQFOA8ZP0BRP1gNPlkCKw==";
        public static void Main(string[] args)
        {
            Part1();
        }

        public static void Part1()
        {
            string text = Utilites.Convert_by16(task1);

            CaesarAlgorithm caesarAlgorithm = new CaesarAlgorithm(text);
            var resultTask1 = caesarAlgorithm.getDecrypt();
            Console.WriteLine(resultTask1);

        }

        public static void Part2()
        {

            string inputBase64Decoded = ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(task2));
            var arrayOFbyte = Convert.FromBase64String(task2);
            Vigenere vigenere = new Vigenere();
            vigenere.Distance(arrayOFbyte);

        }
        public static void Part3()
        {

        }
    }
}