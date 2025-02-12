<?php
require_once('Database.class.php');

class Apply
{
    //OBTENEMOS TODOS LOS APLIQUES DE UN USUARIO
    public static function getAppliesByUserId($id_user)
    {
        $database = new Database();
        $conn = $database->getConnection();

        $stmt = $conn->prepare('SELECT 
            offers.id,
            offers.title,
            offers.description,
            offers.id_course,
            offers.date      AS offerdate,
            offers.location,
            offers.id_company,
            students_offers.id_user,
            students_offers.id_offer,
            students_offers.presentation,
            students_offers.status,
            students_offers.date AS applydate
            FROM offers
            JOIN students_offers 
                ON offers.id = students_offers.id_offer
            WHERE students_offers.id_user = :id_user;
            ');

        $stmt->bindParam(':id_user', $id_user);

        $stmt->execute();
        return $stmt->fetchAll(PDO::FETCH_ASSOC);
    }

    //OBTENEMOS TODOS LOS APLIQUES PARA EL ADMIN    
    public static function getAppliesToAdmin()
    {
        $database = new Database();
        $conn = $database->getConnection();

        $stmt = $conn->prepare('SELECT 
            s.id_user AS student_id_user,
            s.nie AS student_nie,
            s.name AS student_name,
            s.surname AS student_surname,
            s.gendre AS student_gendre,
            s.birthdate AS student_birthdate,
            s.phone AS student_phone,
            s.emer_phone AS student_emer_phone,
            s.nationality AS student_nationality,
            s.car AS student_car,
            s.address AS student_address,
            s.year AS student_year,
            s.register_date AS student_register_date,
            s.cv AS student_cv,

            so.id_offer AS students_offers_id_offer,
            so.presentation AS students_offers_presentation,
            so.status AS students_offers_status,
            so.date AS students_offers_date,

            o.id AS offer_id,
            o.title AS offer_title,
            o.description AS offer_description,
            o.id_course AS offer_id_course,
            o.date AS offer_date,
            o.location AS offer_location,
            o.id_company AS offer_id_company,

            c.id_user AS company_id_user,
            c.name AS company_name,
            c.adress AS company_adress,
            c.telephone AS company_telephone,
            c.contact AS company_contact,
            c.mobile AS company_mobile,
            c.status AS company_status

            FROM students s
            JOIN students_offers so ON s.id_user = so.id_user
            JOIN offers o ON so.id_offer = o.id
            JOIN companies c ON o.id_company = c.id_user
            ORDER BY offer_date ;
            ');


        $stmt->execute();
        return $stmt->fetchAll(PDO::FETCH_ASSOC);
    }


}
