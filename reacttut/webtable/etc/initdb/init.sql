--
-- PostgreSQL database dump
--

-- Dumped from database version 13.2
-- Dumped by pg_dump version 13.2

-- Started on 2021-12-17 01:58:25

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

CREATE DATABASE web_client WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE = 'Russian_Russia.1251';

ALTER DATABASE web_client OWNER TO poler;

\connect web_client

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 200 (class 1259 OID 16637)
-- Name: member; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.member (
    id integer NOT NULL,
    name character varying(30) NOT NULL,
    sername character varying(30) NOT NULL,
    middle_name character varying(30),
    nickname character varying(15) NOT NULL,
    email character varying(50) NOT NULL,
    registration_date date NOT NULL,
    last_activity_date date NOT NULL
);


ALTER TABLE public.member OWNER TO poler;

--
-- TOC entry 201 (class 1259 OID 16646)
-- Name: user_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public.member ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.user_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 2985 (class 0 OID 16637)
-- Dependencies: 200
-- Data for Name: member; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.member (id, name, sername, middle_name, nickname, email, registration_date, last_activity_date) OVERRIDING SYSTEM VALUE VALUES (5, 'Michael', 'Jordan', NULL, 'mjordan', 'mjordan@mail.ru', '2021-07-03', '2021-07-18');
INSERT INTO public.member (id, name, sername, middle_name, nickname, email, registration_date, last_activity_date) OVERRIDING SYSTEM VALUE VALUES (2, 'Vladimir', 'Bogolubov', 'Vladimirovich', 'vbogolubov', 'vbogolubov@mail.ru', '2021-06-10', '2021-06-23');
INSERT INTO public.member (id, name, sername, middle_name, nickname, email, registration_date, last_activity_date) OVERRIDING SYSTEM VALUE VALUES (6, 'Lebron', 'James', NULL, 'ljames', 'ljames@mail.ru', '2021-07-23', '2021-07-23');
INSERT INTO public.member (id, name, sername, middle_name, nickname, email, registration_date, last_activity_date) OVERRIDING SYSTEM VALUE VALUES (12, 'strin', 'string', 'strinvsdvgf', 'stringhvvovdsv', 'useknkvvsdvvr@mail.ru', '2021-07-10', '2021-07-22');
INSERT INTO public.member (id, name, sername, middle_name, nickname, email, registration_date, last_activity_date) OVERRIDING SYSTEM VALUE VALUES (11, 'strin', 'string', 'stringf', 'stringhvvo', 'useknkvvr@mail.ru', '2021-07-15', '2021-07-22');
INSERT INTO public.member (id, name, sername, middle_name, nickname, email, registration_date, last_activity_date) OVERRIDING SYSTEM VALUE VALUES (9, 'strin', 'string', 'stringf', 'string', 'user@mail.ru', '2021-06-22', '2021-07-22');
INSERT INTO public.member (id, name, sername, middle_name, nickname, email, registration_date, last_activity_date) OVERRIDING SYSTEM VALUE VALUES (8, 'Don', 'Wilson', NULL, 'dwilson', 'dwilson@mail.ru', '2021-07-01', '2021-07-21');
INSERT INTO public.member (id, name, sername, middle_name, nickname, email, registration_date, last_activity_date) OVERRIDING SYSTEM VALUE VALUES (14, 'string', 'string', 'string', 'stricscng', 'nokr@exacsple.com', '2021-07-21', '2021-07-23');
INSERT INTO public.member (id, name, sername, middle_name, nickname, email, registration_date, last_activity_date) OVERRIDING SYSTEM VALUE VALUES (7, 'James', 'Harden', NULL, 'jharden', 'jharden@mail.ru', '2021-05-17', '2021-05-31');
INSERT INTO public.member (id, name, sername, middle_name, nickname, email, registration_date, last_activity_date) OVERRIDING SYSTEM VALUE VALUES (4, 'Boris', 'Petrov', 'Ivonovich', 'bpetrov', 'bpetrov@mail.ru', '2021-07-22', '2021-07-25');
INSERT INTO public.member (id, name, sername, middle_name, nickname, email, registration_date, last_activity_date) OVERRIDING SYSTEM VALUE VALUES (1, 'Emil', 'Zakiev', 'Ramilevich', 'ezakiev', 'ezakiev@mail.ru', '2021-05-20', '2021-07-20');
INSERT INTO public.member (id, name, sername, middle_name, nickname, email, registration_date, last_activity_date) OVERRIDING SYSTEM VALUE VALUES (10, 'strin', 'string', 'stringf', 'stringho', 'useknkr@mail.ru', '2021-07-01', '2021-07-22');


--
-- TOC entry 2992 (class 0 OID 0)
-- Dependencies: 201
-- Name: user_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.user_id_seq', 16, true);


--
-- TOC entry 2850 (class 2606 OID 16649)
-- Name: member unique_email; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.member
    ADD CONSTRAINT unique_email UNIQUE (email);


--
-- TOC entry 2852 (class 2606 OID 16643)
-- Name: member unique_nickname; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.member
    ADD CONSTRAINT unique_nickname UNIQUE (nickname);


--
-- TOC entry 2854 (class 2606 OID 16641)
-- Name: member user_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.member
    ADD CONSTRAINT user_pkey PRIMARY KEY (id);


-- Completed on 2021-12-17 01:58:26

--
-- PostgreSQL database dump complete
--

