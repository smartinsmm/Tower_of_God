<?php

$servername = "localhost";
$username = "root";
$password = "";
$dbname = "projetdevb2";
//create connection
$conn = new mysqli($servername, $username, $password, $dbname);

// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}
echo "Connected successfully, now we will show the users.<br><br>";

$sql = "SELECT nom_utilisateur, date_de_naissance FROM joueur";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
  // output data of each row
  while($row = $result->fetch_assoc()) {
    echo "nom_utilisateur: " . $row["nom_utilisateur"]. " - date_de_naissance: " . $row["date_de_naissance"]. "<br>";
  }
} else {
  echo "0 results";
}
$conn->close();
?>