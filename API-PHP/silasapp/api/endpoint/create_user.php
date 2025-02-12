<?php
require_once('../includes/User.class.php');
echo "hola";

if ($_SERVER['REQUEST_METHOD'] == 'POST') {
    
    $body = json_decode(file_get_contents('php://input'), true);
    
    echo "---".$body['email'];
    
    // $email = $body['email'];
    // $password = $body['password'];
    // echo $email."----".$body;
    User::create_user($body['email'], $body['password']);
}

?>
