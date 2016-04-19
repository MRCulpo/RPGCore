using System;
using System.Collections.Generic;


namespace RPG.Lite
{
    [System.Serializable]
    public class LevelPoints
    {
        public int levelPoints;
        public int levelByPoints;

        private int currentPoints;

        public LevelPoints()
        {
            this.levelPoints = 0;
            this.levelByPoints = 0;
        }
        
        public LevelPoints(LevelPoints _levelPoints)
        {
            this.levelPoints = _levelPoints.levelPoints;
            this.levelByPoints = _levelPoints.levelByPoints;
        }

        public void baseLevelPoints()
        {
            this.levelPoints = 0;
            this.levelByPoints = 1;
        }

        public void assingPoints()
        {
            this.currentPoints++;
            if (this.currentPoints >= this.levelByPoints)
            {
                this.levelPoints++;
                this.currentPoints = 0;
            }
        }
    }
}
