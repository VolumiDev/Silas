<?php
require_once('../includes/Database.class.php');

$database = new Database();
$conn = $database->getConnection();

$sql = "SELECT 
            id_user AS company_id, 
            name AS company_name, 
            adress AS company_address, 
            telephone AS company_telephone, 
            contact AS company_contact, 
            mobile AS company_mobile, 
            status AS company_status 
        FROM companies";

$stmt = $conn->prepare($sql);
$stmt->execute();
$companies = $stmt->fetchAll(PDO::FETCH_ASSOC);

header('Content-Type: application/json');
echo json_encode($companies);
?>
