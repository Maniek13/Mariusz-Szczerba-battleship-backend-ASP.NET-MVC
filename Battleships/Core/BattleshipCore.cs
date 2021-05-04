using System;
using System.Collections.Generic;
using Battleships.Objects;

namespace Battleship.Core
{
    public class BattleshipCore
    {
        private static List<Border> borders = new List<Border>();
        private static int id = 0;

        public Border UsersShips()
        {
            List<Border> toDelete = new List<Border>();

            if (borders.Count > 0)
            {
                borders.ForEach((Border border) => 
                {
                    if (border.Time.AddMinutes(30) < DateTime.Now)
                    {
                        toDelete.Add(border);
                    }
                });

                if (toDelete.Count > 0)
                {
                    toDelete.ForEach((Border border) =>
                    {
                        borders.Remove(border);

                    });
                }
            }

            IList<int> P1 = new List<int>();
            IList<int> P2 = new List<int>();


            int[] board1 = Warships();

            System.Threading.Thread.Sleep(200);
   
            int[] board2 = Warships();


            for (int i = 0; i < 100; ++i)
            {
                P1.Add(board1[i]);
                P2.Add(board2[i]);
            }

            var newBorder = new Border
            {
                GameId = ++id,
                StripP1 = P1,
                StripP2 = P2,
                Next = true,
                Time = DateTime.Now
            };

            borders.Add(newBorder);

            return newBorder;
        }

        public Move ComputerMove(int gameId, int player, bool next)
        {
            bool ok = false;
            int hit = 0;
            int field = -1;
            int message = -1;
            Random random = new Random();

            var temp = borders.Find(x => x.GameId == gameId);

            if (temp != null)
            {
                temp.Time = DateTime.Now;
                if (temp.Next == true)
                {
                    message = player;
                    while (ok == false)
                    {
                        int nr = random.Next(0, 100);
                        if (player == 1)
                        {

                            if (temp.StripP2[nr] != 2)
                            {
                                if (temp.StripP2[nr] == 1)
                                {
                                    hit = 1;
                                }

                                temp.StripP2[nr] = 2;

                                if (!temp.StripP2.Contains(1))
                                {
                                    message = 3;
                                    borders.Remove(temp);
                                }

                                field = nr;
                                ok = true;
                            }
                        }
                        else if (player == 2)
                        {

                            if (temp.StripP1[nr] != 2)
                            {
                                if (temp.StripP1[nr] == 1)
                                {
                                    hit = 1;
                                }

                                temp.StripP1[nr] = 2;

                                if (!temp.StripP1.Contains(1))
                                {
                                    message = 3;
                                    borders.Remove(temp);
                                }

                                field = nr;
                                ok = true;
                            }
                        }
                        else
                        {
                            ok = true;
                            message = -1;
                        }
                    }
                    temp.Next = false;
                }
                else
                {
                    if (next == true)
                    {
                        temp.Next = true;
                        message = 4;
                    }
                }

            }
            else
            {
                message = 5;
            }

            return new Move
            {
                Message = message,
                Hit = hit,
                Field = field
            };
        }

        private int[] Warships()
        {
            int[] board = new int[100];

            Random random = new Random();
            int x, y, i1;

            //5
            int position = random.Next(0, 2);
            if (position == 0)
            {
                x = random.Next(0, 6);
                y = random.Next(0, 10);
                i1 = y * 10 + x;

                for (int i = 0; i < 5; ++i)
                {
                    board[i1 + i] = 1;
                }
            }
            else
            {
                x = random.Next(0, 10);
                y = random.Next(0, 6);
                i1 = y * 10 + x;

                for (int i = 0; i < 5; ++i)
                {
                    board[i1 + 10 * i] = 1;
                }
            }

            //4
            bool ok = false;
            position = random.Next(0, 2);

            if (position == 0)
            {
                while (ok == false)
                {
                    x = random.Next(0, 7);
                    y = random.Next(0, 10);
                    i1 = y * 10 + x;

                    int temp = 0;

                    for (int i = 0; i < 4; ++i)
                    {
                        temp = board[i1 + i] == 0 ? temp += 1 : temp;
                        ok = temp == 4;
                    }
                }

                for (int i = 0; i < 4; ++i)
                {
                    board[i1 + i] = 1;
                }
            }
            else
            {
                while (ok == false)
                {
                    x = random.Next(0, 10);
                    y = random.Next(0, 7);
                    i1 = y * 10 + x;

                    int temp = 0;

                    for (int i = 0; i < 4; ++i)
                    {
                        temp = board[i1 + 10 * i] == 0 ? temp += 1 : temp;
                        ok = temp == 4;
                    }
                }

                for (int i = 0; i < 4; ++i)
                {
                    board[i1 + 10 * i] = 1;
                }
            }

            //3
            for (int i = 0; i < 2; ++i)
            {
                ok = false;
                position = random.Next(0, 2);

                if (position == 0)
                {
                    while (ok == false)
                    {
                        x = random.Next(0, 8);
                        y = random.Next(0, 10);
                        i1 = y * 10 + x;

                        int temp = 0;

                        for (int j = 0; j < 3; ++j)
                        {
                            temp = board[i1 + j] == 0 ? temp += 1 : temp;
                            ok = temp == 3;
                        }
                    }

                    for (int j = 0; j < 3; ++j)
                    {
                        board[i1 + j] = 1;
                    }
                }
                else
                {
                    while (ok == false)
                    {
                        x = random.Next(0, 10);
                        y = random.Next(0, 8);
                        i1 = y * 10 + x;

                        int temp = 0;

                        for (int j = 0; j < 3; ++j)
                        {
                            temp = board[i1 + 10 * j] == 0 ? temp += 1 : temp;
                            ok = temp == 3;
                        }
                    }

                    for (int j = 0; j < 3; ++j)
                    {
                        board[i1 + 10 * j] = 1;
                    }
                }
            }


            //2
            ok = false;
            position = random.Next(0, 2);

            if (position == 0)
            {
                while (ok == false)
                {
                    x = random.Next(0, 9);
                    y = random.Next(0, 10);
                    i1 = y * 10 + x;

                    int temp = 0;

                    for (int i = 0; i < 2; i++)
                    {
                        temp = board[i1 + i] == 0 ? temp += 1 : temp;
                        ok = temp == 2;
                    }
                }

                for (int i = 0; i < 2; ++i)
                {
                    board[i1 + i] = 1;
                }
            }
            else
            {
                while (ok == false)
                {
                    x = random.Next(0, 10);
                    y = random.Next(0, 9);
                    i1 = y * 10 + x;

                    int temp = 0;

                    for (int i = 0; i < 2; i++)
                    {
                        temp = board[i1 + 10 * i] == 0 ? temp += 1 : temp;
                        ok = temp == 2;
                    }
                }

                for (int i = 0; i < 2; ++i)
                {
                    board[i1 + 10 * i] = 1;
                }
            }
          

            return board;
        }
    }


}