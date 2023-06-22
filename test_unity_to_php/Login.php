<?php

$servername = "localhost";
$username = "root";
$password = "";
$dbname = "projetdevb2";

// submit user
$loginUser = $_POST["loginUser"];
$loginEmail = $_POST["loginEmail"];


//create connection
$conn = new mysqli($servername, $username, $password, $dbname);

// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}
echo "Connected successfully, now we will show the users.<br><br>";

$sql = "SELECT email FROM joueur WHERE username == " . $loginUser;
$result = $conn->query($sql);

if ($result->num_rows > 0) {
  // output data of each row
  while($row = $result->fetch_assoc()) {
    if($row["nom_utilisateur"] == $loginUser ){
      echo "Login Success.";
    } 
    else{
      echo " wrong User"
    }
  }
} else {
  echo "Username does not exists";
}
$conn->close();
?>