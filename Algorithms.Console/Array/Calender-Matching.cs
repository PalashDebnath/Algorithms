using System;
using System.Collections.Generic;

namespace Algorithms.Problems
{
    public class Meeting
    {
        public int startInMins;
        public int endInMins;
        public string start;
        public string end;

        public Meeting(string start, string end)
        {
            this.start = start;
            this.end = end;
            this.startInMins = ConvertToMinutes(this.start);
            this.endInMins = ConvertToMinutes(this.end);
        }

        private int ConvertToMinutes(string value)
        {
            string[] hold = value.Split(':');
            int hours = Convert.ToInt32(hold[0]);
            int minutes = hours * 60 + Convert.ToInt32(hold[1]);
            return minutes;
        }
    }

    public static class CalenderMatching
    {
        //Time Complexity: O(n)
        //Space Complexity: O(m + n)
        public static List<Meeting> Availability(List<Meeting> myCalender, Meeting myDailyBounds, List<Meeting> coworkerCalender, Meeting coworkerDailyBounds, int meetingDuration)
        {
            List<Meeting> mergeCalander = new List<Meeting>();
            List<Meeting> availability = new List<Meeting>();
            int left = 0, right = 0;
            myCalender.Insert(0, new Meeting("00:00", myDailyBounds.start));
            myCalender.Add(new Meeting(myDailyBounds.end,"23:59"));
            coworkerCalender.Insert(0, new Meeting("00:00", coworkerDailyBounds.start));
            coworkerCalender.Add(new Meeting(coworkerDailyBounds.end,"23:59"));
            while(left < myCalender.Count && right < coworkerCalender.Count)
            {
                if(myCalender[left].startInMins > coworkerCalender[right].startInMins)
                {
                    mergeCalander.Add(coworkerCalender[right]);
                    right = right + 1;
                }
                else
                {
                    mergeCalander.Add(myCalender[left]);
                    left = left + 1;
                }
            }
            while(left < myCalender.Count - 1)
            {
                mergeCalander.Add(myCalender[left]);
                left = left + 1;
            }

            while(right < coworkerCalender.Count - 1)
            {
                mergeCalander.Add(coworkerCalender[right]);
                right = right + 1;
            }
            for(int i = 0; i < mergeCalander.Count - 1; i++)
            {
                if(mergeCalander[i].endInMins >= mergeCalander[i + 1].startInMins && mergeCalander[i].endInMins <= mergeCalander[i + 1].endInMins)
                {
                    mergeCalander[i + 1].startInMins = mergeCalander[i].startInMins;
                }
                else if(mergeCalander[i].endInMins >= mergeCalander[i + 1].startInMins && mergeCalander[i].endInMins > mergeCalander[i + 1].endInMins)
                {
                    mergeCalander[i + 1].startInMins = mergeCalander[i].startInMins;
                    mergeCalander[i + 1].endInMins = mergeCalander[i].endInMins;
                }
            }
            for(int i = 0; i < mergeCalander.Count - 1; i++)
            {
                if((mergeCalander[i + 1].startInMins - mergeCalander[i].endInMins) / meetingDuration >= 1)
                {
                    string start = (mergeCalander[i].endInMins / 60) + ":";
                    if(mergeCalander[i].endInMins % 60 == 0)
                    {
                        start = start + "00";
                    }
                    else
                    {
                        start = start + mergeCalander[i].endInMins % 60;
                    }
                    string end = (mergeCalander[i + 1].startInMins / 60) + ":";
                    if(mergeCalander[i + 1].startInMins % 60 == 0)
                    {
                        end = end + "00";
                    }
                    else
                    {
                        end = end + mergeCalander[i + 1].startInMins % 60;
                    }
                    availability.Add(new Meeting(start, end));
                }
            }
            return availability;
        }
    }
}