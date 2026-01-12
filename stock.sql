-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jan 12, 2026 at 01:33 PM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `stock`
--

-- --------------------------------------------------------

--
-- Table structure for table `stock`
--

CREATE TABLE `stock` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `category_id` int(11) NOT NULL,
  `amount` int(11) NOT NULL,
  `price` int(11) NOT NULL,
  `file_path` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `stock`
--

INSERT INTO `stock` (`id`, `name`, `category_id`, `amount`, `price`, `file_path`) VALUES
(1, 'โคมไฟไม้', 1, 0, 450, 'D:\\c#\\image1.jpg'),
(2, 'กระถางเซรามิกสีขาว', 1, 5, 120, 'D:\\c#\\image2.jpg'),
(3, 'กรอบรูปมินิมอล', 1, 6, 80, 'D:\\c#\\image3.jpg'),
(4, 'ผ้าปูโต๊ะลินิน', 1, 4, 150, 'D:\\c#\\image4.jpg'),
(5, 'เทียนหอม', 1, 12, 90, 'D:\\c#\\image5.jpg'),
(6, 'กระจกขอบไม้', 1, 13, 90, 'D:\\c#\\image6.jpg'),
(7, 'ตะกร้าหวายทรงกลม', 2, 5, 250, 'D:\\c#\\image7.jpg'),
(8, 'กล่องเก็บของ', 2, 8, 150, 'D:\\c#\\image8.jpg'),
(9, 'ที่แขวนผ้า', 2, 3, 90, 'D:\\c#\\image9.jpg'),
(10, 'ขวดแก้วใส', 2, 16, 50, 'D:\\c#\\image10.jpg'),
(11, 'แปรงขัดพื้น', 2, 11, 100, 'D:\\c#\\image11.jpg'),
(12, 'ผ้าเช็ดมือ', 2, 20, 40, 'D:\\c#\\image12.jpg'),
(13, 'สมุดโน๊ต', 3, 23, 60, 'D:\\c#\\image13.jpg'),
(14, 'ปากกามูจิ', 3, 40, 20, 'D:\\c#\\image14.jpg'),
(15, 'กล่องดินสอผ้า', 3, 6, 120, 'D:\\c#\\image15.jpg'),
(16, 'ที่คั่นหนังสือ', 3, 11, 55, 'D:\\c#\\image16.jpg'),
(17, 'สติ๊กเกอร์ตกแต่ง', 3, 36, 30, 'D:\\c#\\image17.jpg'),
(18, 'เทปกระดาษ', 3, 22, 45, 'D:\\c#\\image18.jpg'),
(19, 'กล่องของขวัญ', 4, 2, 90, 'D:\\c#\\image19.jpg'),
(20, 'พวกกุญแจไม้', 4, 8, 65, 'D:\\c#\\image20.jpg'),
(21, 'การ์ดอวยพร', 4, 24, 25, 'D:\\c#\\image21.jpg'),
(22, 'แหวนเงิน', 5, 18, 95, 'D:\\c#\\image22.jpg'),
(23, 'สร้อยเงิน', 5, 6, 155, 'D:\\c#\\image23.jpg'),
(24, 'ต่างหู', 5, 24, 85, 'D:\\c#\\image24.jpg');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `stock`
--
ALTER TABLE `stock`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `stock`
--
ALTER TABLE `stock`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=26;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
