using System;
using System.IO;
using UnityEngine;
using System.Collections.Generic;


public class SaveAsWave : MonoBehaviour
{
    //public GameObject rightHand;
    public bool isTriggered = false;
    const int HEADER_SIZE = 44;
    private int outputRate = 44100;
    private string fileRoot = "Assets/Resources/";
    private string fileName = "audio";
    private string fileEnding = ".wav";
    private bool recOutput;
    private FileStream fileStream;



    void Update()
    {
        if (isTriggered)
        {
            if (recOutput == false)
            {
                Debug.Log("start recording");
                // check if file exists

                CreateEmpty(fileRoot + fileName + fileEnding);

                GameObject.Find("Controller (left)").GetComponent<leftController>().recorder.SetActive(true);
            }
            else
            {
                WriteHeader();
                Debug.Log("stop recording");
                GameObject.Find("Controller (left)").GetComponent<leftController>().recorder.SetActive(false);

            }
            isTriggered = false;
            recOutput = !recOutput;
        }
    }

    void CreateEmpty(string filepath)
    {
        fileStream = new FileStream(filepath, FileMode.Create);
        byte emptyByte = new byte();

        for (int i = 0; i < HEADER_SIZE; i++)
        {
            fileStream.WriteByte(emptyByte);
        }
    }

    void OnAudioFilterRead(float[] data, int channels)
    {
        if (recOutput)
        {
            ConvertAndWrite(data);
        }
    }


    void ConvertAndWrite(float[] dataSource)
    {

        Int16[] intData = new Int16[dataSource.Length];
        //converting in 2 float[] steps to Int16[], //then Int16[] to Byte[]

        Byte[] bytesData = new Byte[dataSource.Length * 2];


        int rescaleFactor = 32767; //to convert float to Int16

        for (int i = 0; i < dataSource.Length; i++)
        {
            intData[i] = (short)(dataSource[i] * rescaleFactor);
            Byte[] byteArr = new Byte[2];
            byteArr = BitConverter.GetBytes(intData[i]);
            byteArr.CopyTo(bytesData, i * 2);
        }

        fileStream.Write(bytesData, 0, bytesData.Length);
    }

    void WriteHeader()
    {
        fileStream.Seek(0, SeekOrigin.Begin);

        Byte[] riff = System.Text.Encoding.UTF8.GetBytes("RIFF");
        fileStream.Write(riff, 0, 4);

        Byte[] chunkSize = BitConverter.GetBytes(fileStream.Length - 8);
        fileStream.Write(chunkSize, 0, 4);

        Byte[] wave = System.Text.Encoding.UTF8.GetBytes("WAVE");
        fileStream.Write(wave, 0, 4);

        Byte[] fmt = System.Text.Encoding.UTF8.GetBytes("fmt ");
        fileStream.Write(fmt, 0, 4);

        Byte[] subChunk1 = BitConverter.GetBytes(16);
        fileStream.Write(subChunk1, 0, 4);

        UInt16 two = 2;
        UInt16 one = 1;

        Byte[] audioFormat = BitConverter.GetBytes(one);
        fileStream.Write(audioFormat, 0, 2);

        Byte[] numChannels = BitConverter.GetBytes(two);
        fileStream.Write(numChannels, 0, 2);

        Byte[] sampleRate = BitConverter.GetBytes(outputRate);
        fileStream.Write(sampleRate, 0, 4);

        Byte[] byteRate = BitConverter.GetBytes(outputRate * two * 2);
        fileStream.Write(byteRate, 0, 4);

        UInt16 blockAlign = (ushort)(two * 2);
        fileStream.Write(BitConverter.GetBytes(blockAlign), 0, 2);

        UInt16 bps = 16;
        Byte[] bitsPerSample = BitConverter.GetBytes(bps);
        fileStream.Write(bitsPerSample, 0, 2);

        Byte[] datastring = System.Text.Encoding.UTF8.GetBytes("data");
        fileStream.Write(datastring, 0, 4);

        Byte[] subChunk2 = BitConverter.GetBytes(fileStream.Length - HEADER_SIZE);
        fileStream.Write(subChunk2, 0, 4);

        fileStream.Close();
    }
}