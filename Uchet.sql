--
-- PostgreSQL database dump
--

-- Dumped from database version 14.2
-- Dumped by pg_dump version 14.2

-- Started on 2022-05-25 00:20:12

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

DROP DATABASE uchet;
--
-- TOC entry 3382 (class 1262 OID 16394)
-- Name: uchet; Type: DATABASE; Schema: -; Owner: postgres
--

CREATE DATABASE uchet WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE = 'Russian_Russia.1251';


ALTER DATABASE uchet OWNER TO postgres;

\connect uchet

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
-- TOC entry 216 (class 1259 OID 16575)
-- Name: dictroomproperty; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.dictroomproperty (
    dictroompropertyid integer NOT NULL,
    propertyname character varying(256) NOT NULL,
    propertygroup character varying(256) NOT NULL,
    displayname character varying(256) NOT NULL
);


ALTER TABLE public.dictroomproperty OWNER TO postgres;

--
-- TOC entry 215 (class 1259 OID 16574)
-- Name: DictRoomProperty_DictRoomPropertyId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public.dictroomproperty ALTER COLUMN dictroompropertyid ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."DictRoomProperty_DictRoomPropertyId_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 218 (class 1259 OID 16588)
-- Name: software; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.software (
    softwareid integer NOT NULL,
    title character varying(200) NOT NULL,
    installanywere integer NOT NULL
);


ALTER TABLE public.software OWNER TO postgres;

--
-- TOC entry 217 (class 1259 OID 16587)
-- Name: Software_SoftwareId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public.software ALTER COLUMN softwareid ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Software_SoftwareId_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 222 (class 1259 OID 16610)
-- Name: os; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.os (
    osid integer NOT NULL,
    osname character varying(256) NOT NULL,
    dictcategoryid integer NOT NULL,
    inventorynumber character varying(20),
    oscount numeric(9,0),
    usedfrom date,
    cost numeric(9,0),
    purchased date,
    charged date,
    dictbudgetid integer NOT NULL,
    dicttypeid integer NOT NULL,
    osserial character varying(100),
    dictbillid integer NOT NULL,
    dictssusageid integer,
    visible integer NOT NULL,
    lastupdate date
);


ALTER TABLE public.os OWNER TO postgres;

--
-- TOC entry 221 (class 1259 OID 16609)
-- Name: os_OSId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public.os ALTER COLUMN osid ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."os_OSId_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 224 (class 1259 OID 16617)
-- Name: osrooms; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.osrooms (
    osroomid integer NOT NULL,
    osid integer NOT NULL,
    roomid integer NOT NULL
);


ALTER TABLE public.osrooms OWNER TO postgres;

--
-- TOC entry 223 (class 1259 OID 16616)
-- Name: osrooms_OSRoomId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public.osrooms ALTER COLUMN osroomid ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."osrooms_OSRoomId_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 212 (class 1259 OID 16551)
-- Name: room; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.room (
    roomid integer NOT NULL,
    roomname character varying(256),
    number character varying(32),
    buildingid integer NOT NULL,
    isactive bit(1) NOT NULL,
    dicttyperoomid integer NOT NULL,
    ownerid integer,
    square numeric(6,2),
    placecount integer,
    dictroomcategoryid integer
);


ALTER TABLE public.room OWNER TO postgres;

--
-- TOC entry 211 (class 1259 OID 16550)
-- Name: room_RoomId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public.room ALTER COLUMN roomid ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."room_RoomId_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 210 (class 1259 OID 16527)
-- Name: roombuilding; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.roombuilding (
    buildingid integer NOT NULL,
    buildingname character varying(256) NOT NULL,
    buildingsname character varying(32),
    address character varying(255),
    nameformatted character varying(255)
);


ALTER TABLE public.roombuilding OWNER TO postgres;

--
-- TOC entry 209 (class 1259 OID 16526)
-- Name: roombuilding_BuildingId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public.roombuilding ALTER COLUMN buildingid ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."roombuilding_BuildingId_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 213 (class 1259 OID 16563)
-- Name: roomproperty; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.roomproperty (
    roompropertyid integer NOT NULL,
    roomid integer NOT NULL,
    dictroompropertyid integer NOT NULL,
    value character varying(256) NOT NULL
);


ALTER TABLE public.roomproperty OWNER TO postgres;

--
-- TOC entry 214 (class 1259 OID 16568)
-- Name: roomproperty_RoomPropertyId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public.roomproperty ALTER COLUMN roompropertyid ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."roomproperty_RoomPropertyId_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 220 (class 1259 OID 16594)
-- Name: softwarerooms; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.softwarerooms (
    softwareroomid integer NOT NULL,
    roomid integer,
    softwareid integer NOT NULL,
    usageduration date
);


ALTER TABLE public.softwarerooms OWNER TO postgres;

--
-- TOC entry 219 (class 1259 OID 16593)
-- Name: softwarerooms_SoftwareRoomId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public.softwarerooms ALTER COLUMN softwareroomid ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."softwarerooms_SoftwareRoomId_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 3368 (class 0 OID 16575)
-- Dependencies: 216
-- Data for Name: dictroomproperty; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- TOC entry 3374 (class 0 OID 16610)
-- Dependencies: 222
-- Data for Name: os; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- TOC entry 3376 (class 0 OID 16617)
-- Dependencies: 224
-- Data for Name: osrooms; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- TOC entry 3364 (class 0 OID 16551)
-- Dependencies: 212
-- Data for Name: room; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- TOC entry 3362 (class 0 OID 16527)
-- Dependencies: 210
-- Data for Name: roombuilding; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- TOC entry 3365 (class 0 OID 16563)
-- Dependencies: 213
-- Data for Name: roomproperty; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- TOC entry 3370 (class 0 OID 16588)
-- Dependencies: 218
-- Data for Name: software; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- TOC entry 3372 (class 0 OID 16594)
-- Dependencies: 220
-- Data for Name: softwarerooms; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- TOC entry 3383 (class 0 OID 0)
-- Dependencies: 215
-- Name: DictRoomProperty_DictRoomPropertyId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."DictRoomProperty_DictRoomPropertyId_seq"', 1, false);


--
-- TOC entry 3384 (class 0 OID 0)
-- Dependencies: 217
-- Name: Software_SoftwareId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Software_SoftwareId_seq"', 1, true);


--
-- TOC entry 3385 (class 0 OID 0)
-- Dependencies: 221
-- Name: os_OSId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."os_OSId_seq"', 1, false);


--
-- TOC entry 3386 (class 0 OID 0)
-- Dependencies: 223
-- Name: osrooms_OSRoomId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."osrooms_OSRoomId_seq"', 1, false);


--
-- TOC entry 3387 (class 0 OID 0)
-- Dependencies: 211
-- Name: room_RoomId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."room_RoomId_seq"', 1, false);


--
-- TOC entry 3388 (class 0 OID 0)
-- Dependencies: 209
-- Name: roombuilding_BuildingId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."roombuilding_BuildingId_seq"', 1, false);


--
-- TOC entry 3389 (class 0 OID 0)
-- Dependencies: 214
-- Name: roomproperty_RoomPropertyId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."roomproperty_RoomPropertyId_seq"', 1, false);


--
-- TOC entry 3390 (class 0 OID 0)
-- Dependencies: 219
-- Name: softwarerooms_SoftwareRoomId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."softwarerooms_SoftwareRoomId_seq"', 1, false);


--
-- TOC entry 3206 (class 2606 OID 16581)
-- Name: dictroomproperty dictroomproperty_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.dictroomproperty
    ADD CONSTRAINT dictroomproperty_pkey PRIMARY KEY (dictroompropertyid);


--
-- TOC entry 3212 (class 2606 OID 16614)
-- Name: os os_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.os
    ADD CONSTRAINT os_pkey PRIMARY KEY (osid);


--
-- TOC entry 3214 (class 2606 OID 16621)
-- Name: osrooms osrooms_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.osrooms
    ADD CONSTRAINT osrooms_pkey PRIMARY KEY (osroomid);


--
-- TOC entry 3202 (class 2606 OID 16555)
-- Name: room room_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.room
    ADD CONSTRAINT room_pkey PRIMARY KEY (roomid);


--
-- TOC entry 3200 (class 2606 OID 16557)
-- Name: roombuilding roombuilding_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.roombuilding
    ADD CONSTRAINT roombuilding_pkey PRIMARY KEY (buildingid);


--
-- TOC entry 3204 (class 2606 OID 16567)
-- Name: roomproperty roomproperty_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.roomproperty
    ADD CONSTRAINT roomproperty_pkey PRIMARY KEY (roompropertyid);


--
-- TOC entry 3208 (class 2606 OID 16592)
-- Name: software software_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.software
    ADD CONSTRAINT software_pkey PRIMARY KEY (softwareid);


--
-- TOC entry 3210 (class 2606 OID 16598)
-- Name: softwarerooms softwarerooms_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.softwarerooms
    ADD CONSTRAINT softwarerooms_pkey PRIMARY KEY (softwareroomid);


--
-- TOC entry 3215 (class 2606 OID 16558)
-- Name: room fk_buildid_roombuilding; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.room
    ADD CONSTRAINT fk_buildid_roombuilding FOREIGN KEY (buildingid) REFERENCES public.roombuilding(buildingid) NOT VALID;


--
-- TOC entry 3216 (class 2606 OID 16582)
-- Name: roomproperty fk_dictroomproperty_roomproperty; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.roomproperty
    ADD CONSTRAINT fk_dictroomproperty_roomproperty FOREIGN KEY (dictroompropertyid) REFERENCES public.dictroomproperty(dictroompropertyid) NOT VALID;


--
-- TOC entry 3220 (class 2606 OID 16622)
-- Name: osrooms fk_osrooms_os; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.osrooms
    ADD CONSTRAINT fk_osrooms_os FOREIGN KEY (osid) REFERENCES public.os(osid) NOT VALID;


--
-- TOC entry 3221 (class 2606 OID 16627)
-- Name: osrooms fk_osrooms_room; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.osrooms
    ADD CONSTRAINT fk_osrooms_room FOREIGN KEY (roomid) REFERENCES public.room(roomid) NOT VALID;


--
-- TOC entry 3217 (class 2606 OID 16569)
-- Name: roomproperty fk_roomproperty_room; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.roomproperty
    ADD CONSTRAINT fk_roomproperty_room FOREIGN KEY (roomid) REFERENCES public.room(roomid) NOT VALID;


--
-- TOC entry 3218 (class 2606 OID 16599)
-- Name: softwarerooms fk_softwarerooms_room; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.softwarerooms
    ADD CONSTRAINT fk_softwarerooms_room FOREIGN KEY (roomid) REFERENCES public.room(roomid) NOT VALID;


--
-- TOC entry 3219 (class 2606 OID 16604)
-- Name: softwarerooms fk_softwarerooms_software; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.softwarerooms
    ADD CONSTRAINT fk_softwarerooms_software FOREIGN KEY (softwareid) REFERENCES public.software(softwareid) NOT VALID;


-- Completed on 2022-05-25 00:20:13

--
-- PostgreSQL database dump complete
--

