using MailKit.Net.Smtp;
using MimeKit;
using System.Text;
using TournamentTrackerLibrary.Models;

namespace TournamentTrackerLibrary.Logic
{
    public static class Email
    {
        public static string Connection { get; set; } = string.Empty;
        public static int Port { get; set; } = 0;
        public static string Login { get; set; } = string.Empty;
        public static string Password { get; set; } = string.Empty;

        public static void SendEmail(MimeMessage message)
        {
            using (var client = new SmtpClient())
            {
                client.Connect(Connection, Port, true);
                // Note: since we don't have an OAuth2 token, disable
                // the XOAUTH2 authentication mechanism.
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                // Note: only needed if the SMTP server requires authentication
                client.Authenticate(Login, Password);
                client.Send(message);
                client.Disconnect(true);
            }
        }

        public static void SendNextRoundNotifications(List<MatchupModel> nextMatchups, string tournamentName = "Tournament Info")
        {
            string subject = tournamentName + " Update";
            string body = string.Empty;
            StringBuilder sb = new StringBuilder();
            MatchupTeamInfoModel? opponent;

            foreach (MatchupModel matchup in nextMatchups)
            {
                foreach (MatchupTeamInfoModel teamInfo in matchup.TeamsInfo)
                {
                    if (teamInfo.TeamCompeting is not null)
                    {
                        sb = new StringBuilder();
                        body = string.Empty;

                        var otherTeam = matchup.TeamsInfo.Where(x => x.TeamCompeting is not null && x.TeamCompeting.Id != teamInfo.TeamCompeting.Id).ToList();
                        if (otherTeam.Count > 0)
                            opponent = otherTeam.First();
                        else opponent = null;

                        if (opponent is not null)
                        {
                            sb.AppendLine($"<h1>You have a new matchup in {matchup.MatchupRound} round!</h1>");
                            sb.AppendLine();
                            sb.Append($"<strong>{teamInfo.TeamCompeting.TeamName}</strong>");
                            sb.Append(" vs ");
                            sb.Append($"<strong>{opponent.TeamCompeting?.TeamName}</strong>");
                            body = sb.ToString();
                        }
                        else
                        {
                            sb.AppendLine("<h1>You have a BYE in the first round of a tournament</h1>");
                            body = sb.ToString();
                        }
                    }

                    if (teamInfo.TeamCompeting is not null)
                    {
                        foreach (PersonModel person in teamInfo.TeamCompeting.TeamMembers)
                        {
                            if (person.Address is not null)
                            {
                                SendEmail(CreateMimeMessage(person.Address, subject, body));
                            }
                        }
                    }
                }
            }
        }

        public static void SendWinnerNotifications(List<TeamModel> teams, MatchupModel matchup, string tournamentName)
        {
            string body = string.Empty;
            string teammatesStr = string.Empty;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"<h1>{tournamentName} has a winner!</h1>");
            sb.AppendLine();
            sb.AppendLine($"Team {matchup?.Winner?.TeamName} has won the tournament!");

            List<PersonModel> teammates = new List<PersonModel>();
            if (matchup is not null && matchup.Winner is not null)
            {
                teammates = matchup.Winner.TeamMembers;

                if (teammates.Count > 0)
                {
                    foreach (PersonModel person in teammates)
                    {
                        teammatesStr += $"{person.FullName}";
                    }
                }

                sb.AppendLine($"Team members were: {teammatesStr}");
                body = sb.ToString();

                foreach (TeamModel team in teams)
                {
                    foreach (PersonModel member in team.TeamMembers)
                    {
                        SendEmail(CreateMimeMessage(member.Address, $"{tournamentName} Tournament Winner - {matchup.Winner.TeamName}", body));
                    }
                }
            }
        }

        private static MimeMessage CreateMimeMessage(string to, string subject, string body)
        {
            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress("Lazik's Tournament Tracker", Login));
            message.To.Add(new MailboxAddress("", to));
            message.Subject = subject;
            message.Body = new TextPart("html") { Text = body };
            return message;
        }
    }
}
