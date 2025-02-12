<?php
require_once('../includes/Database.class.php');

function getAllCompaniesWithOffers() {
    $database = new Database();
    $conn = $database->getConnection();
    
    $sql = "
        SELECT 
            comp.id_user AS company_id,
            comp.name AS company_name,
            comp.adress AS company_address,
            comp.telephone AS company_telephone,
            comp.contact AS company_contact,
            comp.mobile AS company_mobile,
            comp.status AS company_status,
            o.id AS offer_id,
            o.title AS offer_title,
            o.description AS offer_description,
            o.id_course AS offer_course_id,
            o.date AS offer_date,
            o.location AS offer_location,
            CONCAT(course.name, ' (', course.acronim, ')') AS offer_requiriments,
            so.presentation AS application_presentation,
            so.status AS application_status,
            s.id_user AS student_id,
            s.nie AS student_nie,
            s.name AS student_name,
            s.surname AS student_surname,
            s.gendre AS student_gender,
            s.birthdate AS student_birthdate,
            s.phone AS student_phone,
            s.emer_phone AS student_emergency_phone,
            s.nationality AS student_nationality,
            s.car AS student_car,
            s.address AS student_address,
            s.year AS student_year,
            s.register_date AS student_register_date,
            s.cv AS student_cv,
            course.name AS course_name,
            course.acronim AS course_acronim
        FROM companies comp
        LEFT JOIN offers o ON comp.id_user = o.id_company
        LEFT JOIN course ON o.id_course = course.id
        LEFT JOIN students_offers so ON o.id = so.id_offer
        LEFT JOIN students s ON so.id_user = s.id_user
        ORDER BY comp.id_user, o.date DESC
    ";
    
    $stmt = $conn->prepare($sql);
    $stmt->execute();
    return $stmt->fetchAll(PDO::FETCH_ASSOC);
}

if ($_SERVER['REQUEST_METHOD'] == 'GET') {
    $data = getAllCompaniesWithOffers();
    header('Content-Type: application/json');
    echo json_encode($data);
}
?>
